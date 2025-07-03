'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { ColaboradoresEmpty } from '../../Models/Colaboradores';
import { ColaboradoresApi } from '../Apis/ApiColaboradores';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import ColaboradoresWindow from '../Crud/Grids/ColaboradoresWindow';
import { IColaboradores } from '../Interfaces/interface.Colaboradores';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { ColaboradoresService } from '../Services/Colaboradores.service';
import { useColaboradoresComboBox } from '../Hooks/hookColaboradores';
const ColaboradoresComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'colaboradoresInput';
const { systemContext } = useSystemContext();
const colaboradoresService = new ColaboradoresService(
new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = useColaboradoresComboBox(colaboradoresService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<IColaboradores | null>(null);
const [addRecord, setAddRecord] = useState<IColaboradores | null>(null);
const [action, setAction] = useState(ActionAdicionar);
useEffect(() => {
  if (typeof value === 'number' && value > 0 && !selectedValue) {
    loadRecordForEdit(value);
  } else if (!value) {
  handleValueChange(null);
  setAction(ActionAdicionar);
}
}, [value]);

const loadRecordForEdit = async (id: number) => {
  try {
    const record = await colaboradoresService.fetchColaboradoresById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.nome });
  } catch (error) {
  console.log('Erro ao carregar Colaborador:');
}
};

const handleComboChange = (e: any) => {
  const newValue = e.target.value;

  if (newValue && typeof newValue === 'object' && 'id' in newValue && 'nome' in newValue) {
    handleValueChange(newValue);
    setValue(newValue);
    if (newValue.id > 0) {
      loadRecordForEdit(newValue.id);
    }
  } else if (typeof newValue === 'string' && newValue.trim() !== '') {
  const tempValue = { id: 0, nome: newValue };
  handleValueChange(tempValue);

  const matchingItem = filteredOptions.find(item =>
    item.nome.toLowerCase() === newValue.toLowerCase()
  );

  if (matchingItem) {
    handleValueChange(matchingItem);
    setValue(matchingItem);
    loadRecordForEdit(matchingItem.id);
  } else {
  setAction(ActionAdicionar);
  setEditRecord(null);
}
} else {
handleClear();
}
};
const handleFilterChange = (event: any) => {
  const filter = event.filter.value;
  handleFilter(filter);
};
const getCurrentInputValue = (): string => {
  const inputElement = document.querySelector(`.${cssDado} input`) as HTMLInputElement;
  return inputElement?.value || '';
};

const handleClear = () => {
  clearValue();
  setValue(null);
  setAction(ActionAdicionar);
  setEditRecord(null);
};
const handleActionClick = () => {
  if (action === ActionEditar && editRecord) {
    setIsOpen(true);
    return;
  }
  const inputValue = getCurrentInputValue();
  const newRecord = ColaboradoresEmpty();
  newRecord.nome = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newColaboradores?: IColaboradores) => {
  if (newColaboradores) {
    setValue({ id: newColaboradores.id, nome: newColaboradores.nome });
    loadRecordForEdit(newColaboradores.id);
    handleValueChange(newColaboradores);
  }
  handleClose();
};
return (
<>

<style jsx global>{`
  .colaboradores-dropdown-popup-msi {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    z-index: 99999 !important;
    position: absolute !important;
    background: white !important;
    border: 1px solid #ccc !important;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15) !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    min-width: 200px !important;
    height: auto !important;
  }

  .colaboradores-dropdown-popup-msi .k-list {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    background: white !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    height: auto !important;
  }

  .colaboradores-dropdown-popup-msi .k-list-item {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    padding: 8px 12px !important;
    background: white !important;
    color: #333 !important;
    cursor: pointer !important;
    border-bottom: 1px solid #eee !important;
    height: auto !important;
  }

  .colaboradores-dropdown-popup-msi .k-list-item: hover {
    background: #f0f0f0 !important;
  }

  .colaboradores-dropdown-popup-msi * {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    height: auto !important;
  }

  `}</style>
  {(editRecord || addRecord) && isOpen && (
    <ColaboradoresWindow
    isOpen={isOpen}
    onClose={handleClose}
    onSuccess={handleSuccess}
    onError={handleClose}
    selectedColaboradores={editRecord || addRecord || ColaboradoresEmpty()}
    />
    )}

    <div className={`${cssDado} inputCombobox input-container`}>
      <div className='comboboxLabel'>
        <span className='k-floating-label'>{label}</span>
        </div>
        <div className='comboboxBox'>
          <ComboBox
          name={name}
          data={filteredOptions}
          textField='nome'
          dataItemKey='id'
          value={selectedValue}
          className={cssDado}
          allowCustom={true}
          filterable={true}
          loading={loading}
          aria-busy={loading}
          onFilterChange={handleFilterChange}
          onChange={handleComboChange}
          style={{ height: '33px' }}
          clearButton={true}
          suggest={true}
          popupSettings={{
            className: 'colaboradores-dropdown-popup-msi'
          }}
          />

          <label
          title={action === 'Editar' ? 'Editar o item atual' : 'Incluir/Adicionar novo item'}
          className={`input-combobox-action-svg-label-${action.toLowerCase()}`}
          onClick={handleActionClick}
        >
        <SvgIcon icon={action === 'Editar' ? pencilIcon : plusIcon} />
      </label>
    </div>
  </div>
</>
);
};
export default ColaboradoresComboBox;