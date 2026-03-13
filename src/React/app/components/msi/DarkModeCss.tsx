/*
ESSE ARQUIVO É COMPARTILHADO ENTRE VÁRIOS PROJETOS SOURCE GENESSY.

Para personalizar o Dark Mode:
1. Edite o arquivo: "./Darkmode.css"
2. Execute: npm run generate:darkmode
3. Os estilos serão automaticamente atualizados


*/
"use client";
import { useEffect, useLayoutEffect, useState } from 'react';
import { useAppSelector } from '../../store/hooks';
import { selectDarkMode } from '../../store/slices/systemContextSlice';
import { darkModeStyles } from './DarkmodeStyles';
import { darkModeStylesSG } from '@/app/styles/GerAdv_TS/DarkModeStylesSG';
 
 

export default function DarkModeCss() {
  const darkMode = useAppSelector(selectDarkMode);

  // Start with false to match server render and avoid hydration mismatch
  const [mounted, setMounted] = useState(false);
  const [prefersDark, setPrefersDark] = useState<boolean>(false);

  // After hydration, read the actual media query value
  useEffect(() => {
    setMounted(true);
    if (typeof window !== 'undefined' && window.matchMedia) {
      setPrefersDark(window.matchMedia('(prefers-color-scheme: dark)').matches);
    }
  }, []);

  // Only compute shouldInject after mount to guarantee server/client initial render match
  const shouldInject = mounted && (darkMode === 'dark' || (darkMode === 'auto' && prefersDark));

  useLayoutEffect(() => {
    if (typeof window === 'undefined' || !window.matchMedia) return;
    const mq = window.matchMedia('(prefers-color-scheme: dark)');
    const handler = (e: MediaQueryListEvent) => setPrefersDark(e.matches);
    if (mq.addEventListener) mq.addEventListener('change', handler as any);
    else if ((mq as any).addListener) (mq as any).addListener(handler as any);
    return () => {
      if (mq.removeEventListener) mq.removeEventListener('change', handler as any);
      else if ((mq as any).removeListener) (mq as any).removeListener(handler as any);
    };
  }, []);

  // Aplicar classe e estilos inline para garantir prioridade sobre outros estilos
  useLayoutEffect(() => {
    if (typeof window === 'undefined') return;

    const className = 'appsg-dark-mode';
    const apply = shouldInject;

    const html = document.documentElement;
    const body = document.body;

    if (apply) {
      html.classList.add(className);
      // Usar variáveis CSS — a declaração :root dentro do <style> definirá os valores
      html.style.backgroundColor = 'var(--bg-primary)';
      html.style.color = 'var(--text-primary)';
      body.style.backgroundColor = 'var(--bg-primary)';
      body.style.color = 'var(--text-primary)';
    } else {
      html.classList.remove(className);
      // Limpar completamente os estilos inline para voltar ao padrão
      html.style.backgroundColor = '';
      html.style.color = '';
      body.style.backgroundColor = '';
      body.style.color = '';
    }

    return () => {
      // Cleanup: remover classe e estilos inline
      html.classList.remove(className);
      html.style.backgroundColor = '';
      html.style.color = '';
      body.style.backgroundColor = '';
      body.style.color = '';
    };
  }, [shouldInject]);

  // Only inject styles when dark mode should be active
  // This completely removes the CSS from DOM when in light mode
  if (!shouldInject) {
    return null;
  }

  const rootMatches = (darkModeStyles + darkModeStylesSG).match(/:root\s*{[\s\S]*?}/g) || [];
  const rootsInner = rootMatches
    .map((m) => m.replace(/^:root\s*{/, '').replace(/}\s*$/, ''))
    .join('\n');
  const other = (darkModeStyles + darkModeStylesSG).replace(/:root\s*{[\s\S]*?}/g, '');

  // Apply dark mode ONLY when the class is present (respects SwitchDarkMode settings)
  const finalCss = `.appsg-dark-mode {\n${rootsInner}\n}\n${other}`;

  return <style dangerouslySetInnerHTML={{ __html: finalCss }} />
}
;
