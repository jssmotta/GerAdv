'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { AreaEmpty } from '../../Models/Area';
import { AreaApi } from '../Apis/ApiArea';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import AreaWindow from '../Crud/Grids/AreaWindow';
import { IArea } from '../Interfaces/interface.Area';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { AreaService } from '../Services/Area.service';
import { useAreaComboBox } from '../Hooks/hookArea';
const AreaComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'areaInput';
const { systemContext } = useSystemContext();
const areaService = new AreaService(
new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = useAreaComboBox(areaService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<IArea | null>(null);
const [addRecord, setAddRecord] = useState<IArea | null>(null);
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
    const record = await areaService.fetchAreaById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.descricao });
  } catch (error) {
  console.log('Erro ao carregar Area:');
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
  const newRecord = AreaEmpty();
  newRecord.descricao = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newArea?: IArea) => {
  if (newArea) {
    setValue({ id: newArea.id, nome: newArea.descricao });
    loadRecordForEdit(newArea.id);
    handleValueChange(newArea);
  }
  handleClose();
};
return (
<>
{(editRecord || addRecord) && isOpen && (
  <AreaWindow
  isOpen={isOpen}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleClose}
  selectedArea={editRecord || addRecord || AreaEmpty()}
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
export default AreaComboBox;