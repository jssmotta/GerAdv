'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { OperadorGruposAgendaEmpty } from '../../Models/OperadorGruposAgenda';
import { OperadorGruposAgendaApi } from '../Apis/ApiOperadorGruposAgenda';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import OperadorGruposAgendaWindow from '../Crud/Grids/OperadorGruposAgendaWindow';
import { IOperadorGruposAgenda } from '../Interfaces/interface.OperadorGruposAgenda';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { OperadorGruposAgendaService } from '../Services/OperadorGruposAgenda.service';
import { useOperadorGruposAgendaComboBox } from '../Hooks/hookOperadorGruposAgenda';
const OperadorGruposAgendaComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'operadorgruposagendaInput';
const { systemContext } = useSystemContext();
const operadorgruposagendaService = new OperadorGruposAgendaService(
new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = useOperadorGruposAgendaComboBox(operadorgruposagendaService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<IOperadorGruposAgenda | null>(null);
const [addRecord, setAddRecord] = useState<IOperadorGruposAgenda | null>(null);
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
    const record = await operadorgruposagendaService.fetchOperadorGruposAgendaById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.nome });
  } catch (error) {
  console.log('Erro ao carregar Operador Grupos Agenda:');
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
  const newRecord = OperadorGruposAgendaEmpty();
  newRecord.nome = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newOperadorGruposAgenda?: IOperadorGruposAgenda) => {
  if (newOperadorGruposAgenda) {
    setValue({ id: newOperadorGruposAgenda.id, nome: newOperadorGruposAgenda.nome });
    loadRecordForEdit(newOperadorGruposAgenda.id);
    handleValueChange(newOperadorGruposAgenda);
  }
  handleClose();
};
return (
<>
{(editRecord || addRecord) && isOpen && (
  <OperadorGruposAgendaWindow
  isOpen={isOpen}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleClose}
  selectedOperadorGruposAgenda={editRecord || addRecord || OperadorGruposAgendaEmpty()}
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
export default OperadorGruposAgendaComboBox;