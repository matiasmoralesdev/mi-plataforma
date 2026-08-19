<script setup lang="ts">
import { ref } from 'vue';

export interface MenuItem {
    label: string;
    icon?: string;
    to?: string;
    items?: MenuItem[];
}

const props = defineProps<{
    item: MenuItem;
    collapsed?: boolean;
}>();

const expanded = ref(false);

function toggle() {
    expanded.value = !expanded.value;
}
</script>

<template>
    <li>
        <router-link
            v-if="props.item.to && !props.item.items"
            :to="props.item.to"
            :title="props.item.label"
            class="flex items-center gap-2 px-3 py-2 mx-2 rounded-lg text-surface-700 dark:text-surface-100 hover:bg-surface-100 dark:hover:bg-surface-800 transition-colors"
            active-class="bg-primary-50 dark:bg-primary-400/10 text-primary font-medium"
        >
            <i :class="props.item.icon"></i>
            <span v-if="!props.collapsed">{{ props.item.label }}</span>
        </router-link>

        <a
            v-else
            href="#"
            :title="props.item.label"
            class="flex items-center gap-2 px-3 py-2 mx-2 rounded-lg text-surface-700 dark:text-surface-100 hover:bg-surface-100 dark:hover:bg-surface-800 cursor-pointer transition-colors"
            @click.prevent="toggle"
        >
            <i :class="props.item.icon"></i>
            <template v-if="!props.collapsed">
                <span class="flex-1">{{ props.item.label }}</span>
                <i class="pi pi-angle-down transition-transform" :class="{ 'rotate-180': expanded }"></i>
            </template>
        </a>

        <ul v-if="props.item.items && expanded && !props.collapsed" class="list-none m-0 pl-4">
            <AppMenuItem v-for="child in props.item.items" :key="child.label" :item="child" :collapsed="props.collapsed" />
        </ul>
    </li>
</template>
