'use client';
import '@/app/styles/HelpCrud.css';

import React from 'react';

/** Kept for any remaining spread usages — matches fixed theme palette. */
export const pStyle: React.CSSProperties = { color: '#A0AEC0', fontSize: 12.5, lineHeight: 1.6, margin: 0 };

export function Section({ title, children }: { title: string; children: React.ReactNode }) {
  return (
    <div style={{ marginBottom: 20 }}>
      <div className="hc-fieldCaption" style={{ padding: '10px 0 8px 0', borderBottom: '1px solid var(--kendo-neutral-30)', marginBottom: 10 }}>{title}</div>
      {children}
    </div>
  );
}

export function HelpRow({ icon, label, desc }: { icon: React.ReactNode; label: string; desc: string }) {
  return (
    <div className="hc-card hc-anim" style={{ marginBottom: 6 }}>
      <div className="hc-cardToggle" style={{ cursor: 'default' }}>
        <span className="hc-toggleIcon hc-toggleClosed">{icon}</span>
        <div style={{ flex: 1 }}>
          <div className="hc-fieldCaption">{label}</div>
          <div className="hc-value">{desc}</div>
        </div>
      </div>
    </div>
  );
}

export function ExplainBlock({ children }: { children: React.ReactNode }) {
  return <div className="hc-infoBox">{children}</div>;
}

export function DetailItem({ color, label, desc }: { color: string; label: string; desc: string }) {
  return (
    <div className="hc-row" style={{ flexDirection: 'row', alignItems: 'center', gap: 12, padding: '4px 0' }}>
      <div className="hc-infoIcon" style={{ background: color, width: 36, height: 36, fontSize: 12 }}>AB</div>
      <div>
        <span className="hc-label">{label}: </span>
        <span className="hc-value">{desc}</span>
      </div>
    </div>
  );
}

export function GestureRow({ gesture, action }: { gesture: string; action: string }) {
  return (
    <div className="hc-row" style={{ flexDirection: 'row', alignItems: 'center', gap: 12, padding: '6px 0' }}>
      <span className="hc-badgeFK">{gesture}</span>
      <span className="hc-value" style={{ flex: 1 }}>{action}</span>
    </div>
  );
}

export default null;
