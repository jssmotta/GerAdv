'use client';
import React, { useRef } from 'react';
import '@/app/styles/PrintHelpButton.css';
import { SvgIcon } from '@progress/kendo-react-common';
import { printIcon } from '@progress/kendo-svg-icons';

interface PrintHelpButtonProps {
  lastUpdate?: string;
}

const PrintHelpButton: React.FC<PrintHelpButtonProps> = ({ lastUpdate }) => {
  const wrapRef = useRef<HTMLDivElement>(null);
  const PSecondsToStartOnIOS = 500;
  
  const handlePrint = () => {
    const target = wrapRef.current?.closest<HTMLElement>('.hc-root');
    if (!target) { 
      
     setTimeout(() => {
      window.print();
    }, PSecondsToStartOnIOS);
      
      return; }

    // 1. Grab the rendered HTML of .hc-root
    const html = target.innerHTML;

    // 2. Read computed CSS variable values from :root
    const rootStyle = getComputedStyle(document.documentElement);
    const varNames = [
      '--bg-white','--text-color','--primary-color','--primary-hover',
      '--accent-color','--success-color','--warning-color','--error-color',
      '--kendo-primary','--kendo-primary-dark','--kendo-primary-light',
      '--kendo-secondary','--kendo-hover',
      '--kendo-primary-10','--kendo-primary-20','--kendo-primary-30',
      '--kendo-primary-40','--kendo-primary-50','--kendo-primary-60',
      '--kendo-primary-70','--kendo-primary-80','--kendo-primary-90',
      '--kendo-primary-100','--kendo-primary-110','--kendo-primary-120',
      '--kendo-primary-130','--kendo-primary-140','--kendo-primary-150',
      '--kendo-primary-160','--kendo-primary-170','--kendo-primary-180',
      '--kendo-primary-190','--kendo-primary-200','--kendo-primary-210',
      '--kendo-primary-220',
      '--kendo-neutral-10','--kendo-neutral-20','--kendo-neutral-30',
      '--kendo-neutral-40','--kendo-neutral-50','--kendo-neutral-60',
      '--kendo-neutral-70','--kendo-neutral-80','--kendo-neutral-90',
      '--kendo-neutral-100','--kendo-neutral-110','--kendo-neutral-120',
      '--kendo-neutral-130','--kendo-neutral-140',
      '--kendo-error-10','--kendo-error-20',
      '--kendo-success-90',
    ];
    const cssVarDeclarations = varNames
      .map(v => `${v}: ${rootStyle.getPropertyValue(v).trim() || 'initial'};`)
      .join('\n  ');

    // 3. Build a full standalone HTML document
    const fullHtml = `<!DOCTYPE html>
<html><head><meta charset="utf-8">
<style>

@media print {
  .print-header {
    padding: 12px 0;
    border-bottom: 2px solid #1a365d;
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 11px;
    font-weight: 600;
    letter-spacing: 1.5px;
    text-transform: uppercase;
    color: #1a365d;
    text-align: center;
  }

  .print-footer {
    padding: 12px 0;
    border-top: 1px solid #cbd5e0;
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 9px;
    color: #718096;
    text-align: center;
    letter-spacing: 0.5px;
  }
}
 
@media print {
  .hmi-root {
    break-before: page;
    page-break-before: always;
    padding: 0;
    margin: 0;
  }

  .hmi-header {
    margin-bottom: 20px;
  }

  .hmi-header-label {
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 14px;
    font-weight: 700;
    color: #1a365d;
    text-transform: uppercase;
    letter-spacing: 1px;
    margin-bottom: 4px;
  }

 

  .hmi-header-title {
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 11px;
    color: #4a5568;
    margin: 0;
  }

  .hmi-item {
    padding: 10px 0;
  }
  .hmi-item--bordered {
    border-bottom: 1px solid #e2e8f0;
  }

  .hmi-content {
    flex: 1;
  }

  .hmi-title {
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 11px;
    font-weight: 600;
    color: #1a202c;
    margin: 0 0 2px 0;
  }

  .hmi-title--danger {
    color: #c53030;
  }

  .hmi-title--whatsapp {
    color: #128c7e;
  }

  .hmi-description {
    font-family: 'Segoe UI', Arial, sans-serif;
    font-size: 10px;
    color: #718096;
    margin: 0;
    line-height: 1.4;
  }

  .no-printer {
    display: none !important;
  }
}

:root {
  ${cssVarDeclarations}
}

.hc-anim { animation: none; }
.hc-detail-anim { animation: none; }

.hc-root {
  font-family: -apple-system, BlinkMacSystemFont, "SF Pro Text", "Segoe UI", Roboto, sans-serif;
  max-width: 100%; margin: 0 auto; background: #fff; border: none; box-shadow: none;
  overflow: visible; padding: 10px 20px;
}
.hc-h1 {
  text-transform: uppercase;
  display: block;
  font-family: 'Segoe UI', Arial, sans-serif;
  font-size: 28px;
  font-weight: 300;
  color: #1a365d;
  letter-spacing: 0.35em;
  line-height: 1.15;
  margin: 0 0 20px 0;
  text-align: center;
}
.hc-header { padding: 28px 32px 24px; background: #fff; }
.hc-headerTop { display:flex; align-items:baseline; gap:10px; margin-bottom:8px; }
.hc-title { margin:0; font-size:26px; font-weight:800; color:var(--kendo-primary-dark); letter-spacing:-0.03em; line-height:1.15 }
.hc-countBadge { display:inline-flex; align-items:center; justify-content:center; min-width:32px; height:32px; padding:0 10px; border-radius:50%; background:var(--kendo-primary); color:#fff; font-size:14px; font-weight:700; line-height:1; margin-bottom:2px }
.hc-subtitle { display: block; font-size:16px; color:var(--kendo-neutral-110); font-weight:400; margin:10px; margin-left: 20px; line-height:1.5 }
.hc-infoBox { width: 100%; display:block; min-height: 50px; align-items:flex-start; gap:14px; padding:16px 20px; margin-bottom:22px; border-radius:12px; background:var(--kendo-primary-10); border:1px solid var(--kendo-primary-20); }
.hc-infoIcon { width:44px; height:44px; border-radius:50%; background:var(--kendo-primary); color:#fff; display:flex; align-items:center; justify-content:center; flex-shrink:0 }
.hc-infoText { width: 100%; margin:10px 0 0 0; font-size:14px; line-height:1.7; color:var(--kendo-primary-90); font-weight:400; }
.hc-controls { display: flex; justify-content: center; gap: 12px; }
.hc-pill { display:inline-flex; align-items:center; gap:7px; padding:16px 44px; border-radius:6px; font-size:13px; font-weight:500; background:var(--kendo-neutral-10); color:var(--text-color); border:none; }
.hc-pillActive { background:var(--kendo-primary-10); color:var(--kendo-primary); border:1px solid var(--kendo-primary-20) }
.hc-dot { margin-right: 8px; width:8px; height:8px; border-radius:50%; display:inline-block; flex-shrink:0 }
.hc-collapseAll { display:none; }
.hc-red { color:red !important; }
.hc-divider { height:1px; background:var(--kendo-neutral-30); margin:0 32px }
.hc-searchWrap { display:none; }
.hc-list { padding: 20px 0 16px; }
.hc-card { border:none; }
.hc-cardOpen { border-color:var(--kendo-primary-60); box-shadow:0 4px 12px rgba(37,99,235,0.10) }
.hc-cardToggle { display:flex; align-items:center; width:100%; padding:16px 20px; background:transparent; border:none; gap:12px; color:var(--kendo-primary-200); text-align:left; }
.hc-toggleIcon { width:28px; height:28px; border-radius:6px; display:inline-flex; align-items:center; justify-content:center; font-size:14px; font-weight:700; flex-shrink:0; line-height:1; }
.hc-toggleOpen { background:var(--kendo-primary-20); color:var(--kendo-primary) }
.hc-toggleClosed { background:var(--kendo-neutral-20); color:var(--kendo-neutral-120) }
.hc-fieldNum { font-size:12px; font-weight:600; color:var(--kendo-neutral-90); font-variant-numeric:tabular-nums; flex-shrink:0; min-width:22px }
.hc-fieldCaption { font-size:15px; font-weight:600; line-height:1.4; color:var(--kendo-primary-200); flex:1 }
.hc-badgeReq { font-size:10px; font-weight:600; text-transform:lowercase; padding:4px 10px; border-radius:5px; background:var(--kendo-error-10); color:var(--error-color); flex-shrink:0; white-space:nowrap }
.hc-badgeFK { display:inline-flex; align-items:center; gap:4px; font-size:10px; font-weight:600; padding:4px 9px; border-radius:5px; background:var(--kendo-primary-10); color:var(--kendo-primary); flex-shrink:0 }
.hc-detail { padding:6px 20px 20px 68px; display:flex; flex-direction:column; gap:18px; border-top:1px solid var(--kendo-neutral-20) }
.hc-row { display:flex; flex-direction:column; gap:6px }
.hc-label { font-size:11px; font-weight:600; text-transform:uppercase; letter-spacing:.08em; color:var(--kendo-neutral-120) }
.hc-value { font-size:14px; line-height:1.6; color:var(--text-color); font-weight:400 }
.hc-valueMono { font-size:13px; line-height:1.55; color:var(--kendo-primary-200); font-family:"SF Mono","Cascadia Code","Fira Code","JetBrains Mono",monospace; background:var(--kendo-neutral-10); padding:10px 14px; border-radius:8px; border-left:3px solid var(--kendo-primary) }
.hc-reqTag { display:inline-flex; align-items:center; gap:6px; padding:5px 12px; border-radius:7px; font-size:12px; font-weight:600; width:fit-content }
.hc-reqDot { width:6px; height:6px; border-radius:50%; display:inline-block }
.hc-tableCode { display:inline-flex; align-items:center; gap:6px; padding:6px 12px; border-radius:7px; font-size:13px; font-weight:600; background:var(--kendo-primary-10); color:var(--kendo-primary); font-family:"SF Mono","Cascadia Code","Fira Code",monospace; border:1px solid var(--kendo-primary-20) }
.hc-empty { text-align:center; padding:48px 16px; color:var(--kendo-neutral-90); font-size:14px }
.hc-ctaWrap { display:none !important; }
.hc-footer { display:none !important; }
.no-printer { display:none !important; }
.hmi-root { display:block !important; }

.hc-h1 { font-family: 'Segoe UI', Arial, sans-serif; font-size: 28px; font-weight: 300; letter-spacing: 0.35em; color: #1a365d; }

.hc-infoText { font-family: 'Segoe UI', Arial, sans-serif; font-size: 12px; font-weight: 400; color: #4a5568; line-height: 1.6; }

.hc-pill { font-family: 'Segoe UI', Arial, sans-serif; font-size: 11px; font-weight: 600; letter-spacing: 0.05em; color: #2d3748; }

.hc-fieldCaption { font-family: 'Segoe UI', Arial, sans-serif; font-size: 13px; font-weight: 700; color: #1a202c; }

.hc-fieldNum { font-family: 'Segoe UI', Arial, sans-serif; font-size: 10px; font-weight: 600; color: #718096; }

.hc-label { font-family: 'Segoe UI', Arial, sans-serif; font-size: 9px; font-weight: 700; letter-spacing: 0.1em; color: #718096; }

.hc-value { font-family: 'Segoe UI', Arial, sans-serif; font-size: 11px; font-weight: 400; color: #2d3748; }

.hc-valueMono { font-family: 'Cascadia Code', 'Fira Code', 'JetBrains Mono', monospace; font-size: 10px; color: #1a365d; }

.hc-badgeReq { font-family: 'Segoe UI', Arial, sans-serif; font-size: 9px; font-weight: 700; letter-spacing: 0.05em; }

.hc-reqTag { font-family: 'Segoe UI', Arial, sans-serif; font-size: 10px; font-weight: 600; }

.print-header { letter-spacing: 0.15em; }

/* Kendo SVG fallback sizing */
.k-svg-icon svg, .k-icon svg, svg.k-svg-i-grid, svg { max-width:24px; max-height:24px; }

* { box-sizing: border-box; }
html, body { margin:0; padding:0; background:#fff; }

@page { size: A4 portrait; margin: 15mm 12mm; }
</style>
</head>
<body>
 
<table class="print-table">
  <thead>
    <tr><td>
    <div class="print-header">
      ${process.env.NEXT_PUBLIC_TITLE || 'Menphis Sistemas Inteligentes'}
    </div>
    </td></tr>
  </thead>
  <tfoot>
    <tr><td>
      <div class="print-footer">
       © ${(new Date().getFullYear().toString())=="2026" ? "2026" : "2026-" + (new Date().getFullYear().toString())} ${process.env.NEXT_PUBLIC_TITLE || 'Menphis Sistemas Inteligentes'} — Documento gerado automaticamente
       ${lastUpdate ? `— Última atualização: ${lastUpdate}` : ''}
      </div>
    </td></tr>
  </tfoot>
  <tbody>
    <tr><td>
      <div class="print-content">
       <div class="hc-root">${html}</div>
      </div>
    </td></tr>
  </tbody>
</table>

</body></html>`;

    // 4. Create a blob URL and load it in a hidden iframe
    const blob = new Blob([fullHtml], { type: 'text/html;charset=utf-8' });
    const url = URL.createObjectURL(blob);

    const iframeId = '__phb-print-iframe__';
    document.getElementById(iframeId)?.remove();

    const iframe = document.createElement('iframe');
    iframe.id = iframeId;
    iframe.style.cssText = 'position:fixed;top:-10000px;left:-10000px;width:210mm;height:297mm;border:none;';
    iframe.src = url;

    iframe.onload = () => {
      URL.revokeObjectURL(url);
      setTimeout(() => {
        iframe.contentWindow?.focus();
        iframe.contentWindow?.print();
        // Cleanup
        setTimeout(() => document.getElementById(iframeId)?.remove(), 1000);
      }, 150);
    };

    document.body.appendChild(iframe);
  };

  return (
    <div ref={wrapRef} className="hc-ctaWrap no-printer">
      <span onClick={handlePrint} title="Imprima esta ajuda - seja consciente!" className="hc-ctaBtnPrint">
        <SvgIcon icon={printIcon} />        
      </span>
    </div>
  );
};

export default PrintHelpButton;
