'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { ProSucumbenciaEmpty } from '../../Models/ProSucumbencia';
import { ProSucumbenciaApi } from '../Apis/ApiProSucumbencia';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import ProSucumbenciaWindow from '../Crud/Grids/ProSucumbenciaWindow';
import { IProSucumbencia } from '../Interfaces/interface.ProSucumbencia';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { ProSucumbenciaService } from '../Services/ProSucumbencia.service';
import { useProSucumbenciaComboBox } from '../Hooks/hookProSucumbencia';
const ProSucumbenciaComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'prosucumbenciaInput';
const { systemContext } = useSystemContext();
const prosucumbenciaService = new ProSucumbenciaService(
new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = useProSucumbenciaComboBox(prosucumbenciaService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<IProSucumbencia | null>(null);
const [addRecord, setAddRecord] = useState<IProSucumbencia | null>(null);
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
    const record = await prosucumbenciaService.fetchProSucumbenciaById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.nome });
  } catch (error) {
  console.log('Erro ao carregar Pro Sucumbencia:');
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
  const newRecord = ProSucumbenciaEmpty();
  newRecord.nome = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newProSucumbencia?: IProSucumbencia) => {
  if (newProSucumbencia) {
    setValue({ id: newProSucumbencia.id, nome: newProSucumbencia.nome });
    loadRecordForEdit(newProSucumbencia.id);
    handleValueChange(newProSucumbencia);
  }
  handleClose();
};
return (
<>
{(editRecord || addRecord) && isOpen && (
  <ProSucumbenciaWindow
  isOpen={isOpen}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleClose}
  selectedProSucumbencia={editRecord || addRecord || ProSucumbenciaEmpty()}
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
export default ProSucumbenciaComboBox;