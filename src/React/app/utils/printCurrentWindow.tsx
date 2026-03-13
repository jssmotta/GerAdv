"use client";
export const printCurrentWindow = (formId: string) => {
    try {
      // try to find the container by formId and scope all searches to it
      const container = document.getElementById(formId) || document.querySelector(`#${formId}`) || undefined;

      // prefer k-window-title inside the container if present, otherwise fallback to global
      const kTitleEl = container?.querySelector('.k-window-title') ?? document.querySelector('.k-window-title');
      const title = (kTitleEl && kTitleEl.textContent && kTitleEl.textContent.trim()) || document.title || (document.querySelector('title')?.textContent ?? '');

      const elements = Array.from((container ?? document).querySelectorAll<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>('input, textarea, select'))
        // only visible and non-hidden
        .filter(el => {
          if (el instanceof HTMLInputElement && el.type === 'hidden') return false;
          // skip elements that are not displayed
          const style = window.getComputedStyle(el as Element);
          if (style.display === 'none' || style.visibility === 'hidden') return false;
          return true;
        });

      const rows = elements.map((el, idx) => {
        let label = '';
        // try label[for=id] or label[for=name] (some components bind label to name instead of id)
        const id = el.id;
  // all elements in the list are input/textarea/select, so use the known .name property safely
  const nameAttr = ((el as HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement).name) || '';
        if (id) {
          const lbl = document.querySelector(`label[for="${id}"]`);
          if (lbl && lbl.textContent) label = lbl.textContent.trim();
        }
        // try label[for=name] when no id-bound label found
        if (!label && nameAttr) {
          const lblByName = document.querySelector(`label[for="${nameAttr}"]`);
          if (lblByName && lblByName.textContent) label = lblByName.textContent.trim();
        }
        // try wrapped label
        if (!label) {
          const parentLabel = el.closest('label');
          if (parentLabel && parentLabel.textContent) label = parentLabel.textContent.trim();
        }
        // fallback to aria-label, placeholder, id — do NOT use the raw name attribute as the printed label
        if (!label) label = (el.getAttribute && (el.getAttribute('aria-label') || el.getAttribute('placeholder'))) || id || `Campo ${idx + 1}`;

        // se label contém '_' => não imprimir
        if (label.includes('_')) {
          return null;
        }

        let value = '';
        if (el instanceof HTMLInputElement) {
          if (el.type === 'checkbox' || el.type === 'radio') {
            // incluir somente se estiver checado
            if (el.checked) value = 'Sim';
            else value = ''; // sem valor => será filtrado
          } else {
            value = el.value ?? '';
          }
        } else if (el instanceof HTMLSelectElement) {
          value = Array.from(el.selectedOptions).map(o => o.text.trim()).filter(t => t).join(', ');
        } else if (el instanceof HTMLTextAreaElement) {
          value = el.value ?? '';
        }

        const labelStr = String(label).trim();
        const valueStr = String(value ?? '').trim();

        // somente retornar se houver valor
        if (!valueStr) return null;

        return { label: labelStr, value: valueStr };
      }).filter(Boolean) as { label: string; value: string }[];

      const popup = window.open('', '_blank', 'width=900,height=700,scrollbars=yes');
      if (!popup) {
        alert('Não foi possível abrir a janela de impressão. Verifique bloqueadores de popup.');
        return;
      }

      const escapeHtml = (s: string) => s
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;');

      // footer text from NEXT_PUBLIC env var (inlined at build time by Next.js)
      const footerText = process.env.NEXT_PUBLIC_FOOTER_PRINT || 'www.menphis.com.br';
      const dateTime = new Date().toLocaleString('pt-BR', { dateStyle: 'short', timeStyle: 'short' });

      const style = `
        body { font-family: Arial, Helvetica, sans-serif; margin: 20px; color: #222; }
        h1 { font-size: 18px; margin-bottom: 12px; }
        table { width: 100%; border-collapse: collapse; margin-bottom: 18px; }
        th, td { padding: 8px 10px; border: 1px solid #ddd; vertical-align: top; }
        th { background: #f5f5f5; text-align: left; width: 30%; }
        /* modern footer */
        .print-footer { position: fixed; left: 0; right: 0; bottom: 0; border-top: 1px solid #e6e6e6; background: #fff; display: flex; justify-content: space-between; align-items: center; padding: 10px 18px; gap: 12px; font-size: 12px; color: #556; }
        .footer-left { text-overflow: ellipsis; overflow: hidden; white-space: nowrap; }
        .footer-right { white-space: nowrap; }
        @media print {
          body { margin-bottom: 64px; }
          th { background: #eee; -webkit-print-color-adjust: exact; }
          .print-footer { position: fixed; bottom: 0; left: 0; right: 0; }
        }
      `;

      const rowsHtml = rows.map(r => `
        <tr>
          <th>${escapeHtml(r.label)}</th>
          <td>${escapeHtml(r.value)}</td>
        </tr>`).join('\n');

      // Adicionar funcionalidade de swipe to close para mobile
      const mobileSwipeScript = `
        <script>
          (function() {
            // Detectar se é mobile
            const isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ||
                            (window.innerWidth <= 768);
            
            if (!isMobile) return;

            let touchStartX = 0;
            let touchStartY = 0;
            let touchStartTime = 0;

            // Adicionar indicador visual de swipe
            const swipeIndicator = document.createElement('div');
            swipeIndicator.innerHTML = '';
            swipeIndicator.style.cssText = \`
              position: fixed;
              top: 15px;
              right: 15px;
              background: rgba(0, 0, 0, 0.7);
              color: white;
              padding: 8px 12px;
              border-radius: 20px;
              font-size: 12px;
              z-index: 10000;
              opacity: 0.8;
              font-family: Arial, sans-serif;
              pointer-events: none;
            \`;
            document.body.appendChild(swipeIndicator);

            // Ocultar indicador após 3 segundos
            setTimeout(() => {
              if (swipeIndicator && swipeIndicator.parentNode) {
                swipeIndicator.style.opacity = '0';
                swipeIndicator.style.transition = 'opacity 0.5s';
                setTimeout(() => {
                  if (swipeIndicator.parentNode) {
                    swipeIndicator.parentNode.removeChild(swipeIndicator);
                  }
                }, 500);
              }
            }, 3000);

            function handleTouchStart(e) {
              if (e.touches && e.touches.length === 1) {
                touchStartX = e.touches[0].clientX;
                touchStartY = e.touches[0].clientY;
                touchStartTime = Date.now();
              }
            }

            function handleTouchEnd(e) {
              if (e.changedTouches && e.changedTouches.length === 1) {
                const touchEndX = e.changedTouches[0].clientX;
                const touchEndY = e.changedTouches[0].clientY;
                const touchEndTime = Date.now();
                
                const deltaX = touchEndX - touchStartX;
                const deltaY = touchEndY - touchStartY;
                const deltaTime = touchEndTime - touchStartTime;
                
                // Verificar se foi um swipe para a direita
                const isRightSwipe = deltaX > 80 && Math.abs(deltaY) < Math.abs(deltaX);
                const isQuickSwipe = deltaX > 40 && deltaTime < 300 && Math.abs(deltaY) < Math.abs(deltaX);
                
                if (isRightSwipe || isQuickSwipe) {
                  window.close();
                }
              }
            }

            document.addEventListener('touchstart', handleTouchStart, { passive: true });
            document.addEventListener('touchend', handleTouchEnd, { passive: true });
          })();
        </script>
      `;

      const content = `<!doctype html>
        <html>
          <head>
            <meta charset="utf-8" />
            <title>Impressão - ${escapeHtml(title)}</title>
            <style>${style}</style>
          </head>
          <body>
            <h1>${escapeHtml(title.replace("- Editando registro nro.:"," - Código. "))}</h1>
            ${rows.length ? `<table><tbody>${rowsHtml}</tbody></table>` : '<p>Nenhum campo com valor encontrado na página.</p>'}
            <div class="print-footer">
              <div class="footer-left">${escapeHtml(String(footerText || ''))}</div>
              <div class="footer-right">${escapeHtml(String(dateTime))}</div>
            </div>
            ${mobileSwipeScript}
          </body>
        </html>`;

      popup.document.open();
      popup.document.write(content);
      popup.document.close();
      popup.focus();
      // allow rendering then call print
      setTimeout(() => {
        try {
          popup.print();
        } catch (err) {
          if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
            console.error('Erro ao imprimir popup', err);
          }
        }
      }, 500);
    } catch (err) {
      // silent catch but log
      // eslint-disable-next-line no-console
       if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.error('PrintCurrentWindow erro:', err);
       }
    }
};