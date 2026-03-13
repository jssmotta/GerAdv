"use client";

// Função auxiliar que coleta e retorna o texto
export const getWindowContent = (formId: string, printHeaderFooter: boolean = false): string => {
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

      // Montar o texto para copiar com caption + conteúdo usando \r\n
      const cleanTitle = title.replace("- Editando registro nro.:", " - Código. ");
      const dateTime = new Date().toLocaleString('pt-BR', { dateStyle: 'short', timeStyle: 'short' });
      const footerText = process.env.NEXT_PUBLIC_FOOTER_PRINT || 'www.menphis.com.br';

      let textToCopy = '';
      
      // Adicionar header se printHeaderFooter for true
      if (printHeaderFooter) {
        textToCopy += cleanTitle + '\r\n';
        textToCopy += '='.repeat(Math.max(0, cleanTitle.length)) + '\r\n\r\n';
      }

      if (rows.length > 0) {
        rows.forEach(row => {
          textToCopy += `${row.label}: ${row.value}\r\n`;
        });
      } else {
        textToCopy += 'Nenhum campo com valor encontrado na página.\r\n';
      }

      // Adicionar footer se printHeaderFooter for true
      if (printHeaderFooter) {
        textToCopy += '\r\n' + '-'.repeat(50) + '\r\n';
        textToCopy += `${footerText} - ${dateTime}`;
      }

      return textToCopy;
    } catch (err) {
      // silent catch but log
      // eslint-disable-next-line no-console
       if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.error('GetWindowContent erro:', err);
       }
       return '';
    }
};

// Função legacy que mantém a funcionalidade de copiar direto (para compatibilidade)
export const copyCurrentWindow = (formId: string, printHeaderFooter: boolean = false) => {
    try {
      const textToCopy = getWindowContent(formId, printHeaderFooter);
      
      if (!textToCopy) {
        alert('Não foi possível obter o conteúdo da janela.');
        return;
      }

      // Copiar para a área de transferência
      navigator.clipboard.writeText(textToCopy).then(() => {
        alert('Conteúdo copiado para a área de transferência!');
      }).catch(err => {
        // Fallback para navegadores mais antigos
        const textArea = document.createElement('textarea');
        textArea.value = textToCopy;
        textArea.style.position = 'fixed';
        textArea.style.left = '-999999px';
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();
        
        try {
          const successful = document.execCommand('copy');
          if (successful) {
            alert('Conteúdo copiado para a área de transferência!');
          } else {
            alert('Não foi possível copiar o conteúdo. Tente novamente.');
          }
        } catch (execErr) {
          if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
            console.error('Erro ao copiar usando execCommand:', execErr);
          }
          alert('Erro ao copiar o conteúdo para a área de transferência.');
        }
        
        document.body.removeChild(textArea);
      });
    } catch (err) {
      // silent catch but log
      // eslint-disable-next-line no-console
       if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.error('CopyCurrentWindow erro:', err);
       }
    }
};