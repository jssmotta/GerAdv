"use client";
import React from 'react';

interface ExtendedGridColumnState {
  id?: string;
  field: string;
  title?: string;
  hidden?: boolean;
  width?: number;
  orderIndex?: number;
}

interface GridColumnMenuProps {
  columnsState: ExtendedGridColumnState[];
  onColumnsStateChange: (newState: ExtendedGridColumnState[]) => void;
}

export const GridColumnMenu = ({ columnsState, onColumnsStateChange }: GridColumnMenuProps) => {
  
  const handleColumnToggle = (field: string) => {
    const newState = columnsState.map(col => 
      col.field === field 
        ? { ...col, hidden: !col.hidden }
        : col
    );
    onColumnsStateChange(newState);
  };

  const handleSelectAll = () => {
    const newState = columnsState.map(col => ({ ...col, hidden: false }));
    onColumnsStateChange(newState);
  };

  const handleDeselectAll = () => {
    const newState = columnsState.map(col => ({ ...col, hidden: true }));
    onColumnsStateChange(newState);
  };

  return (
    <div className="grid-column-menu">
      <div className="column-menu-header">
        <h4>Colunas Visíveis</h4>
        <div className="column-menu-actions">
          <button onClick={handleSelectAll} className="btn-select-all">
            Selecionar Todos
          </button>
          <button onClick={handleDeselectAll} className="btn-deselect-all">
            Desmarcar Todos
          </button>
        </div>
      </div>
      
      <div className="column-menu-list">
        {columnsState.map((column) => (
          <div key={column.field} className="column-menu-item">
            <label>
              <input
                type="checkbox"
                checked={!column.hidden}
                onChange={() => handleColumnToggle(column.field)}
              />
              {/* AQUI É A MUDANÇA PRINCIPAL: usar title ao invés de field */}
              <span>{column.title || column.field}</span>
            </label>
          </div>
        ))}
      </div>
      
      <div className="column-menu-footer">
        <button className="btn-apply">Aplicar</button>
        <button className="btn-reset">Reset</button>
      </div>
    </div>
  );
};