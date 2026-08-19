<script setup lang="ts">
import { useLayout } from './composables/layout';

const { isDarkTheme, toggleDarkMode, toggleMenu } = useLayout();
</script>

<template>
    <header class="fixed top-0 inset-x-0 z-40 h-16 flex items-center justify-between px-4 bg-surface-0 dark:bg-surface-900 border-b border-surface-200 dark:border-surface-700">
        <div class="flex items-center gap-3">
            <button
                type="button"
                class="flex items-center justify-center w-10 h-10 rounded-full hover:bg-surface-100 dark:hover:bg-surface-800 text-surface-700 dark:text-surface-100"
                @click="toggleMenu"
            >
                <i class="pi pi-bars text-xl"></i>
            </button>
            <span class="text-lg font-semibold text-surface-900 dark:text-surface-0">MiPlataforma</span>
        </div>

        <button
            type="button"
            class="flex items-center justify-center w-10 h-10 rounded-full hover:bg-surface-100 dark:hover:bg-surface-800 text-surface-700 dark:text-surface-100"
            @click="toggleDarkMode"
        >
            <i :class="isDarkTheme ? 'pi pi-sun' : 'pi pi-moon'" class="text-xl"></i>
        </button>
    </header>
</template>
