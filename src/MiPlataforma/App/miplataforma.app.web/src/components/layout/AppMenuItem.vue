<script setup lang="ts">
import { ref } from 'vue';

export interface MenuItem {
  label: string;
  icon?: string;
  to?: string;
  items?: MenuItem[];
}

const props = withDefaults(
  defineProps<{
    item: MenuItem;
    level?: number;
  }>(),
  { level: 0 }
);

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
      :style="{ marginLeft: `${props.level}rem` }"
      active-class="active-route"
    >
      <i class="layout-menuitem-icon" :class="props.item.icon"></i>
      <span>{{ props.item.label }}</span>
    </router-link>

    <a v-else href="#" :style="{ marginLeft: `${props.level}rem` }" @click.prevent="toggle">
      <i class="layout-menuitem-icon" :class="props.item.icon"></i>
      <span>{{ props.item.label }}</span>
      <i class="pi pi-angle-down layout-submenu-toggler" :class="{ rotated: expanded }"></i>
    </a>

    <Transition name="layout-submenu">
      <ul v-if="props.item.items && expanded" class="layout-menu-section">
        <AppMenuItem v-for="child in props.item.items" :key="child.label" :item="child" :level="props.level + 1" />
      </ul>
    </Transition>
  </li>
</template>
