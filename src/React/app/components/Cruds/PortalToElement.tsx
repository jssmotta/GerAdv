// PortalToElement.tsx com modificações
'use client';

import React, { useEffect, useRef, useState, useId } from 'react';
import { createPortal } from 'react-dom';

// Registro global de todos os portais - modificado para suportar hierarquia
const GLOBAL_REGISTRY = {
  // Armazena todos os portais ativos por seletor e ID de formulário
  portals: {} as Record<
    string,
    Map<string, { element: HTMLElement; formId: string }>
  >,

  // Registra um portal para um seletor específico
  register(selector: string, id: string, formId: string) {
    if (!this.portals[selector]) {
      this.portals[selector] = new Map();
    }
    const element = document.getElementById(id);
    if (element) {
      this.portals[selector].set(id, { element, formId });
    }
  },

  // Remove um portal de um seletor
  unregister(selector: string, id: string) {
    if (this.portals[selector]) {
      this.portals[selector].delete(id);
      if (this.portals[selector].size === 0) {
        delete this.portals[selector];
      }
    }
  },

  // Limpa todos os portais para um seletor, exceto um específico
  // Modificado para não remover portais parentais
  clearExcept(selector: string, exceptId: string, formId: string) {
    if (this.portals[selector]) {
      // Não remover portais de formulários diferentes ou portais parentais
      this.portals[selector].forEach((data, id) => {
        // Se é o mesmo formId (mesmo contexto) e não é o portal atual, remove
        if (data.formId === formId && id !== exceptId) {
          const element = document.getElementById(id);
          if (element && element.parentNode) {
            element.parentNode.removeChild(element);
          }
          this.portals[selector].delete(id);
        }
      });
    }
  },
};

interface PortalToElementProps {
  targetSelector: string;
  children: React.ReactNode;
  className: string;
  id?: string;
  formId: string; // Adicionar formId para identificação do contexto
}

const PortalToElement: React.FC<PortalToElementProps> = ({
  targetSelector,
  children,
  className,
  id = 'default',
  formId, // Usar formId para evitar fechamento em cascata
}) => {
  // Use React's useId hook for stable ID generation across server and client
  const reactId = useId();
  const uniqueId = useRef(
    `portal-${id}-${reactId.replace(/:/g, '-')}`
  );
  const containerRef = useRef<HTMLDivElement | null>(null);
  const [mounted, setMounted] = useState(false);
  const targetRef = useRef<HTMLElement | null>(null);
  const observerRef = useRef<MutationObserver | null>(null);
  const timerRef = useRef<NodeJS.Timeout | null>(null);
  const mountAttempts = useRef(0);
  const maxAttempts = 10;
  const attemptInterval = 100; // ms

  // Função para encontrar o elemento alvo
  const findTargetElement = (): HTMLElement | null => {
    try {
      const elements = document.querySelectorAll(targetSelector);
      if (elements.length === 0) return null;

      // Para o primeiro render, pegue o primeiro elemento
      if (!targetRef.current && mountAttempts.current === 0) {
        return elements[0] as HTMLElement;
      }

      // Para renders subsequentes, pegue o último elemento
      return elements[elements.length - 1] as HTMLElement;
    } catch (e) {
      console.error('Erro ao buscar elemento alvo:', e);
      return null;
    }
  };

  // Função para anexar o portal ao alvo
  const attachPortal = () => {
    try {
      // Incrementa a contagem de tentativas
      mountAttempts.current += 1;

      // Encontra o elemento alvo
      const target = findTargetElement();
      if (!target) {
        // Se não encontrou e ainda não atingiu o máximo de tentativas, continua tentando
        if (mountAttempts.current < maxAttempts) {
          return false;
        } else {
          console.warn(
            `Não foi possível encontrar alvo '${targetSelector}' após ${maxAttempts} tentativas`
          );
          return false;
        }
      }

      // Limpa outros portais para este seletor, mas apenas no mesmo contexto (formId)
      GLOBAL_REGISTRY.clearExcept(targetSelector, uniqueId.current, formId);

      // Se o portal ainda não foi criado, cria agora
      if (!containerRef.current) {
        const container = document.createElement('div');
        container.id = uniqueId.current;
        container.className = `${className} portal-container`;
        container.dataset.portalFor = targetSelector;
        container.dataset.formId = formId; // Adicionar atributo de data para formId
        containerRef.current = container;

        // Registra este portal com seu formId
        GLOBAL_REGISTRY.register(targetSelector, uniqueId.current, formId);
      }

      // Anexa ao elemento alvo se necessário
      if (containerRef.current && !target.contains(containerRef.current)) {
        target.appendChild(containerRef.current);
        targetRef.current = target;
        setMounted(true);
        return true;
      } else if (
        containerRef.current &&
        target.contains(containerRef.current)
      ) {
        // Já está anexado
        targetRef.current = target;
        setMounted(true);
        return true;
      }

      return false;
    } catch (e) {
      console.error('Erro ao anexar portal:', e);
      return false;
    }
  };

  useEffect(() => {
    if (typeof window === 'undefined') return;

    // Tenta anexar imediatamente
    attachPortal();

    // Configura timer para tentar anexar periodicamente
    timerRef.current = setInterval(() => {
      if (attachPortal() || mountAttempts.current >= maxAttempts) {
        // Se conseguiu anexar ou atingiu o máximo de tentativas, cancela o timer
        if (timerRef.current) {
          clearInterval(timerRef.current);
          timerRef.current = null;
        }
      }
    }, attemptInterval);

    // Configura observer para reagir a mudanças no DOM
    observerRef.current = new MutationObserver(() => {
      // Só tenta anexar novamente se ainda não estiver montado
      if (!mounted) {
        attachPortal();
      }
    });

    observerRef.current.observe(document.body, {
      childList: true,
      subtree: true,
    });

    // Função de cleanup
    return () => {
      if (observerRef.current) {
        observerRef.current.disconnect();
      }

      if (timerRef.current) {
        clearInterval(timerRef.current);
      }

      if (containerRef.current && containerRef.current.parentNode) {
        containerRef.current.parentNode.removeChild(containerRef.current);
      }

      GLOBAL_REGISTRY.unregister(targetSelector, uniqueId.current);
    };
  }, [targetSelector, className, mounted, formId]); // Adicionar formId às dependências

  // Renderiza o portal apenas quando estiver montado
  return mounted && containerRef.current
    ? createPortal(children, containerRef.current)
    : null;
};

export default PortalToElement;
