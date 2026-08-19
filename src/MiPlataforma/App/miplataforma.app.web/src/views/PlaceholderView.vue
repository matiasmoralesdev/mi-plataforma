<script setup lang="ts">
defineProps<{
  title?: string;
}>();
</script>

<template>
  <div class="bg-surface-0 dark:bg-surface-900 rounded-2xl shadow-sm p-6">
    <h1 class="text-2xl font-semibold text-surface-900 dark:text-surface-0 mb-2">{{ title ?? 'Nueva página' }}</h1>
    <p class="text-muted-color">Implementa aquí el contenido de esta pantalla.</p>
  </div>
</template>
