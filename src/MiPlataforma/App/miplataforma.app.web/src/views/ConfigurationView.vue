<script setup lang="ts">
import { useToast } from 'primevue/usetoast';

const toast = useToast();

defineProps<{
  title?: string;
}>();

function showError() {
  toast.add({ severity: 'error', summary: 'Error Message', detail: 'Message Detail', life: 3000 });
}

</script>

<template>
  <div class="bg-surface-0 dark:bg-surface-900 rounded-2xl shadow-sm p-6">
    <h1 class="text-2xl font-semibold text-surface-900 dark:text-surface-0 mb-2"> Configuración </h1>
    <p class="text-muted-color">Pantalla de configuración</p>
  </div>

  <div class="bg-surface-0 dark:bg-surface-900 rounded-2xl shadow-sm mt-6 p-6">
    <Button label="Mostrar error" icon="pi pi-times" class="p-button-danger" @click="showError" />
  </div>
</template>
