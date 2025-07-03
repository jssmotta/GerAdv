'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { PosicaoOutrasPartesEmpty } from '../../Models/PosicaoOutrasPartes';
import { PosicaoOutrasPartesApi } from '../Apis/ApiPosicaoOutrasPartes';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import PosicaoOutrasPartesWindow from '../Crud/Grids/PosicaoOutrasPartesWindow';
import { IPosicaoOutrasPartes } from '../Interfaces/interface.PosicaoOutrasPartes';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { PosicaoOutrasPartesService } from '../Services/PosicaoOutrasPartes.service';
import { usePosicaoOutrasPartesComboBox } from '../Hooks/hookPosicaoOutrasPartes';
const PosicaoOutrasPartesComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'posicaooutraspartesInput';
const { systemContext } = useSystemContext();
const posicaooutraspartesService = new PosicaoOutrasPartesService(
new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = usePosicaoOutrasPartesComboBox(posicaooutraspartesService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<IPosicaoOutrasPartes | null>(null);
const [addRecord, setAddRecord] = useState<IPosicaoOutrasPartes | null>(null);
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
    const record = await posicaooutraspartesService.fetchPosicaoOutrasPartesById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.descricao });
  } catch (error) {
  console.log('Erro ao carregar Posicao Outras Partes:');
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
  const newRecord = PosicaoOutrasPartesEmpty();
  newRecord.descricao = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newPosicaoOutrasPartes?: IPosicaoOutrasPartes) => {
  if (newPosicaoOutrasPartes) {
    setValue({ id: newPosicaoOutrasPartes.id, nome: newPosicaoOutrasPartes.descricao });
    loadRecordForEdit(newPosicaoOutrasPartes.id);
    handleValueChange(newPosicaoOutrasPartes);
  }
  handleClose();
};
return (
<>

<style jsx global>{`
  .posicaooutraspartes-dropdown-popup-msi {
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

  .posicaooutraspartes-dropdown-popup-msi .k-list {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    background: white !important;
    max-height: 300px !important;
    overflow-y: auto !important;
    height: auto !important;
  }

  .posicaooutraspartes-dropdown-popup-msi .k-list-item {
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

  .posicaooutraspartes-dropdown-popup-msi .k-list-item: hover {
    background: #f0f0f0 !important;
  }

  .posicaooutraspartes-dropdown-popup-msi * {
    display: block !important;
    visibility: visible !important;
    opacity: 1 !important;
    height: auto !important;
  }

  `}</style>
  {(editRecord || addRecord) && isOpen && (
    <PosicaoOutrasPartesWindow
    isOpen={isOpen}
    onClose={handleClose}
    onSuccess={handleSuccess}
    onError={handleClose}
    selectedPosicaoOutrasPartes={editRecord || addRecord || PosicaoOutrasPartesEmpty()}
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
            className: 'posicaooutraspartes-dropdown-popup-msi'
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
export default PosicaoOutrasPartesComboBox;