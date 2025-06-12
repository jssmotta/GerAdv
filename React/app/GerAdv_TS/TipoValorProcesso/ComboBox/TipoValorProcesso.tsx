'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { TipoValorProcessoEmpty } from '../../Models/TipoValorProcesso';
import { TipoValorProcessoApi } from '../Apis/ApiTipoValorProcesso';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import TipoValorProcessoWindow from '../Crud/Grids/TipoValorProcessoWindow';
import { ITipoValorProcesso } from '../Interfaces/interface.TipoValorProcesso';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { TipoValorProcessoService } from '../Services/TipoValorProcesso.service';
import { useTipoValorProcessoComboBox } from '../Hooks/hookTipoValorProcesso';
const TipoValorProcessoComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'tipovalorprocessoInput';
const { systemContext } = useSystemContext();
const tipovalorprocessoService = new TipoValorProcessoService(
new TipoValorProcessoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = useTipoValorProcessoComboBox(tipovalorprocessoService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<ITipoValorProcesso | null>(null);
const [addRecord, setAddRecord] = useState<ITipoValorProcesso | null>(null);
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
    const record = await tipovalorprocessoService.fetchTipoValorProcessoById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.descricao });
  } catch (error) {
  console.log('Erro ao carregar Tipo Valor Processo:');
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
  const newRecord = TipoValorProcessoEmpty();
  newRecord.descricao = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newTipoValorProcesso?: ITipoValorProcesso) => {
  if (newTipoValorProcesso) {
    setValue({ id: newTipoValorProcesso.id, nome: newTipoValorProcesso.descricao });
    loadRecordForEdit(newTipoValorProcesso.id);
    handleValueChange(newTipoValorProcesso);
  }
  handleClose();
};
return (
<>
{(editRecord || addRecord) && isOpen && (
  <TipoValorProcessoWindow
  isOpen={isOpen}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleClose}
  selectedTipoValorProcesso={editRecord || addRecord || TipoValorProcessoEmpty()}
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
        onFilterChange={handleFilterChange}
        onChange={handleComboChange}
        style={{ height: '33px' }}
        clearButton={true}
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
export default TipoValorProcessoComboBox;