<script setup lang="ts">
import AppMenuItem, { type MenuItem } from './AppMenuItem.vue';

interface MenuSection {
  label: string;
  items: MenuItem[];
}

defineProps<{
  collapsed?: boolean;
}>();

const model: MenuSection[] = [
  {
    label: 'Inicio',
    items: [{ label: 'Dashboard', icon: 'pi pi-home', to: '/' }]
  },
  {
    label: 'General',
    items: [
      { label: 'Elemento 1', icon: 'pi pi-file', to: '/elemento-1' },
      { label: 'Elemento 2', icon: 'pi pi-file', to: '/elemento-2' }
    ]
  },
  {
    label: 'Sistema',
    items: [{ label: 'Configuración', icon: 'pi pi-cog', to: '/configuracion' }]
  }
];
</script>

<template>
  <nav class="py-3">
    <ul v-for="section in model" :key="section.label" class="list-none m-0 p-0 mb-2">
      <li v-if="!collapsed" class="px-5 pt-3 pb-1 text-xs font-semibold uppercase tracking-wide text-muted-color">
        {{ section.label }}
      </li>
      <AppMenuItem v-for="item in section.items" :key="item.label" :item="item" :collapsed="collapsed" />
    </ul>
  </nav>
</template>
