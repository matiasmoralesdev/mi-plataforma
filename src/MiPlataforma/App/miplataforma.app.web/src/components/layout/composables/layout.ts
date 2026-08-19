import { computed, reactive } from 'vue';

interface LayoutConfig {
    darkTheme: boolean;
}

interface LayoutState {
    staticMenuDesktopInactive: boolean;
    staticMenuMobileActive: boolean;
}

const layoutConfig = reactive<LayoutConfig>({
    darkTheme: typeof window !== 'undefined' && window.matchMedia('(prefers-color-scheme: dark)').matches
});

const layoutState = reactive<LayoutState>({
    staticMenuDesktopInactive: false,
    staticMenuMobileActive: false
});

// keep the initial DOM class in sync with the preferred color scheme
if (typeof document !== 'undefined' && layoutConfig.darkTheme) {
    document.documentElement.classList.add('app-dark');
}

export function useLayout() {
    const isDesktop = () => window.innerWidth > 991;

    const executeDarkModeToggle = () => {
        layoutConfig.darkTheme = !layoutConfig.darkTheme;
        document.documentElement.classList.toggle('app-dark', layoutConfig.darkTheme);
    };

    const toggleDarkMode = () => {
        if (!document.startViewTransition) {
            executeDarkModeToggle();

            return;
        }

        document.startViewTransition(() => executeDarkModeToggle());
    };

    const toggleMenu = () => {
        if (isDesktop()) {
            layoutState.staticMenuDesktopInactive = !layoutState.staticMenuDesktopInactive;
        } else {
            layoutState.staticMenuMobileActive = !layoutState.staticMenuMobileActive;
        }
    };

    const hideMobileMenu = () => {
        layoutState.staticMenuMobileActive = false;
    };

    const isDarkTheme = computed(() => layoutConfig.darkTheme);
    const isSidebarCollapsed = computed(() => layoutState.staticMenuDesktopInactive);
    const isMobileMenuActive = computed(() => layoutState.staticMenuMobileActive);

    return {
        layoutConfig,
        layoutState,
        isDarkTheme,
        isSidebarCollapsed,
        isMobileMenuActive,
        toggleDarkMode,
        toggleMenu,
        hideMobileMenu,
        isDesktop
    };
}
