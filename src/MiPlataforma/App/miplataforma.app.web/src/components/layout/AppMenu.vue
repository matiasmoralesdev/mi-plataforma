<script setup lang="ts">
import AppMenuItem, { type MenuItem } from './AppMenuItem.vue';

interface MenuSection {
  label: string;
  items: MenuItem[];
}

// TODO: reemplaza estas secciones/items por el menu real de tu plataforma
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
  <ul class="layout-menu">
    <li v-for="section in model" :key="section.label" class="layout-root-menuitem">
      <div class="layout-menuitem-root-text">{{ section.label }}</div>
      <ul class="layout-menu-section">
        <AppMenuItem v-for="item in section.items" :key="item.label" :item="item" />
      </ul>
    </li>
  </ul>
</template>
