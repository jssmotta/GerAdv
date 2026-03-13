"use client";

import React, { useState, useEffect } from "react";
import "@/app/styles/HelpCrud.css";
import { Button } from "@progress/kendo-react-buttons";
import { Input } from "@progress/kendo-react-inputs";
import { SvgIcon } from "@progress/kendo-react-common";
import { searchIcon } from "@progress/kendo-svg-icons";
import HelpMenuIcons from "./HelpMenuIcons";
import PrintHelpButton from "./PrintHelpButton";
import InputInput from "../../Inputs/InputInput";

export interface HelpField {
  caption: string;
  description: string;
  acceptedValues: string;
  required: boolean;  
  relatedTable?: React.ReactNode | null;
  columnName: string;
}

export interface HelpCrudProps {
  title: string;
  infoDescription: string;
  fields: HelpField[];
  whatsAppNumber?: string;
  lastUpdate?: string;
  recursive?: boolean;
}

const HelpCrud: React.FC<HelpCrudProps> = ({
  title,
  infoDescription,
  fields,
  lastUpdate,
  recursive = false,
  whatsAppNumber = process.env.NEXT_PUBLIC_WHATSAPP_NUMBER || undefined,
}) => {
  const [search, setSearch] = useState("");
  const [filterRequired, setFilterRequired] = useState<boolean | null>(null);
  const [collapsedSet, setCollapsedSet] = useState<Set<number>>(new Set());

  const filtered = fields.filter((f) => {
    const ms =
      !search ||
      f.caption.toLowerCase().includes(search.toLowerCase()) ||
      f.description.toLowerCase().includes(search.toLowerCase());
    const mr = filterRequired === null || f.required === filterRequired;
    return ms && mr;
  });

  const totalRequired = fields.filter((f) => f.required).length;
  const totalOptional = fields.length - totalRequired;
  const allCollapsed =
    filtered.length > 0 &&
    filtered.every((f) => collapsedSet.has(fields.indexOf(f)));

  const toggle = (globalIdx: number) => {
    setCollapsedSet((prev) => {
      const next = new Set(prev);
      if (next.has(globalIdx)) next.delete(globalIdx);
      else next.add(globalIdx);
      return next;
    });
  };

  const toggleAll = () => {
    if (allCollapsed) {
      setCollapsedSet(new Set());
    } else {
      const all = new Set<number>();
      filtered.forEach((f) => all.add(fields.indexOf(f)));
      setCollapsedSet(all);
    }
  };

  const whatsAppUrl = `https://wa.me/${whatsAppNumber}?text=${encodeURIComponent(
    `Olá, estou na ajuda e tenho dúvida sobre ${title}, poderia me ajudar?`
  )}`;

  useEffect(() => {
    const handler = (e: KeyboardEvent) => {
      if (e.key === "Escape") {
        setSearch("");
        setFilterRequired(null);
        setCollapsedSet(new Set());
      }
    };
    window.addEventListener("keydown", handler);
    return () => window.removeEventListener("keydown", handler);
  }, []);

  const SvgLink = () => (
    <svg width="12" height="12" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2.5" strokeLinecap="round" strokeLinejoin="round" style={{ flexShrink: 0 }}>
      <path d="M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71" />
      <path d="M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71" />
    </svg>
  );

  return (
    <div className="hc-root">  
    <h1 className="hc-h1">{title}</h1>
      <div className="hc-divider" />

      {infoDescription && (
        <div className="hc-infoBox">
          <p className="hc-infoText">{infoDescription}</p>
        </div>
      )}      

      <div className="hc-divider" />

      <div className="hc-controls">        
        

        <div className={`hc-pill ${filterRequired === true ? "hc-pillActive" : ""}`} onClick={() => setFilterRequired((p) => (p === true ? null : true))}>
          <span className="hc-dot" style={{ background: "#EF4444" }} />
          <span className="hc-red">{totalRequired} obrigatório{totalRequired !== 1 ? "s" : ""}</span>
        </div>
        
        <div className={`hc-pill ${filterRequired === false ? "hc-pillActive" : ""}`} onClick={() => setFilterRequired((p) => (p === false ? null : false))}>
          <span className="hc-dot" style={{ background: "#3B82F6" }} />
          {totalOptional} opciona{totalOptional !== 1 ? "is" : "l"}
        </div>
        <span className="hc-collapseAll" onClick={toggleAll} title={allCollapsed ? "Expandir todos" : "Recolher todos"} aria-label={allCollapsed ? "Expandir todos" : "Recolher todos"}>
          {allCollapsed ? "+" : "-"}
        </span>
      </div>


      {/* Search */}
      <div className="hc-searchWrap">
        <div className="hc-searchSvg">
          <SvgIcon icon={searchIcon} />
        </div>
        <InputInput
          type="text"
          placeholder="Buscar campo..."
          value={search}
          onChange={(e: any) => setSearch(e.target.value)}
          className="input-search hc-searchInput"          
          aria-label="Buscar campo" id={"0"} name={"search"}        />
        {search && (
          <Button className="hc-clearBtn" onClick={() => setSearch("")}>✕</Button>
        )}
      </div>

      {/* List */}
      <div className="hc-list" role="list">
        {filtered.length === 0 && (
          <div className="hc-empty">Nenhum campo encontrado.</div>
        )}

        {filtered.map((field, idx) => {
          const globalIdx = fields.indexOf(field);
          const isCollapsed = collapsedSet.has(globalIdx);

          return (
            <div key={globalIdx} className={`hc-card ${isCollapsed ? '' : 'hc-cardOpen'} hc-anim`} style={{ animationDelay: `${idx * 35}ms` }} role="listitem">
              <div className="hc-cardToggle" onClick={() => toggle(globalIdx)} aria-expanded={!isCollapsed}>
                <span className={`hc-toggleIcon ${isCollapsed ? 'hc-toggleClosed' : 'hc-toggleOpen'}`}>
                  {isCollapsed ? "＋" : "－"}
                </span>
                <span className="hc-fieldNum">{String(globalIdx + 1).padStart(2, "0")}</span>
                <span className="hc-fieldCaption">{field.caption}</span>
                {field.required && <span className="hc-badgeReq">obrigatório</span>}
                {field.relatedTable && (
                  <span className="hc-badgeFK"><SvgLink /> {field.relatedTable}</span>
                )}
              </div>

              {!isCollapsed && (
                <div className="hc-detail hc-detail-anim">
                  <div className="hc-row">
                    <span className="hc-label">Descrição</span>
                    <span className="hc-value">{field.description || "—"}</span>
                  </div>
                  <div className="hc-row">
                    <span className="hc-label">Valores aceitos</span>
                    <div className="hc-valueMono">{field.acceptedValues || "—"}</div>
                  </div>
                  <div className="hc-row">
                    <span className="hc-label">Obrigatório</span>
                    <span className="hc-reqTag" style={{ background: field.required ? "#FEE2E2" : "#D1FAE5", color: field.required ? "#DC2626" : "#10B981" }}>
                      <span className="hc-reqDot" style={{ background: field.required ? "#DC2626" : "#10B981" }} />
                      {field.required ? "Sim — preenchimento obrigatório" : "Não — campo opcional"}
                    </span>
                  </div>
                  {field.relatedTable && (
                    <div className="hc-row">
                      <span className="hc-label">Tabela relacionada</span>
                      <code className="hc-tableCode">
                        <SvgLink /> {field.relatedTable}
                      </code>
                    </div>
                  )}
                </div>
              )}
            </div>
          );
        })}
      </div>

      {!recursive && (
            <HelpMenuIcons />
      )}      
      
 

      {/* Footer */}
      <footer className="hc-footer">
        <span>{filtered.length}&nbsp;de&nbsp;{fields.length}&nbsp;campo{fields.length !== 1 ? "s" : ""}</span>
        {lastUpdate && <span>&nbsp;—&nbsp;{lastUpdate}</span>}
        <PrintHelpButton lastUpdate={lastUpdate} />

      </footer>

           {/* WhatsApp CTA */}
      {whatsAppNumber && (
        <div className="hc-ctaWrap no-printer" title="Estamos disponíveis em horário comercial de Brasília">
          <p className="hc-ctaText">Ainda em dúvida? Ou gostaria de dar uma sugestão? Fale agora com a gente.</p>
          <a href={whatsAppUrl} target="_blank" rel="noopener noreferrer" className="hc-ctaBtn">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="currentColor" style={{ flexShrink: 0 }}>
              <path d="M17.472 14.382c-.297-.149-1.758-.867-2.03-.967-.273-.099-.471-.148-.67.15-.197.297-.767.966-.94 1.164-.173.199-.347.223-.644.075-.297-.15-1.255-.463-2.39-1.475-.883-.788-1.48-1.761-1.653-2.059-.173-.297-.018-.458.13-.606.134-.133.298-.347.446-.52.149-.174.198-.298.298-.497.099-.198.05-.371-.025-.52-.075-.149-.669-1.612-.916-2.207-.242-.579-.487-.5-.669-.51-.173-.008-.371-.01-.57-.01-.198 0-.52.074-.792.372-.272.297-1.04 1.016-1.04 2.479 0 1.462 1.065 2.875 1.213 3.074.149.198 2.096 3.2 5.077 4.487.709.306 1.262.489 1.694.625.712.227 1.36.195 1.871.118.571-.085 1.758-.719 2.006-1.413.248-.694.248-1.289.173-1.413-.074-.124-.272-.198-.57-.347m-5.421 7.403h-.004a9.87 9.87 0 01-5.031-1.378l-.361-.214-3.741.982.998-3.648-.235-.374a9.86 9.86 0 01-1.51-5.26c.001-5.45 4.436-9.884 9.888-9.884 2.64 0 5.122 1.03 6.988 2.898a9.825 9.825 0 012.893 6.994c-.003 5.45-4.437 9.884-9.885 9.884m8.413-18.297A11.815 11.815 0 0012.05 0C5.495 0 .16 5.335.157 11.892c0 2.096.547 4.142 1.588 5.945L.057 24l6.305-1.654a11.882 11.882 0 005.683 1.448h.005c6.554 0 11.89-5.335 11.893-11.893a11.821 11.821 0 00-3.48-8.413z" />
            </svg>
            Nos chame no WhatsApp
          </a>
        </div>
      )}

    </div>
  );
};
export default HelpCrud;
