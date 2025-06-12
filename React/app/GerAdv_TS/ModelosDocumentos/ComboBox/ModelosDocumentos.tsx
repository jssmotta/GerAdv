'use client';
import React, { useEffect, useState } from 'react';
import { ComboBox } from '@progress/kendo-react-dropdowns';
import { ModelosDocumentosEmpty } from '../../Models/ModelosDocumentos';
import { ModelosDocumentosApi } from '../Apis/ApiModelosDocumentos';
import { useSystemContext } from '@/app/context/SystemContext';
import { DadosSelectProps } from '@/app/models/DadosSelectProps';
import ModelosDocumentosWindow from '../Crud/Grids/ModelosDocumentosWindow';
import { IModelosDocumentos } from '../Interfaces/interface.ModelosDocumentos';
import { pencilIcon, plusIcon, xIcon } from '@progress/kendo-svg-icons';
import { SvgIcon } from '@progress/kendo-react-common';
import { ActionAdicionar, ActionEditar } from '@/app/tools/crud';
import { ModelosDocumentosService } from '../Services/ModelosDocumentos.service';
import { useModelosDocumentosComboBox } from '../Hooks/hookModelosDocumentos';
const ModelosDocumentosComboBox: React.FC<DadosSelectProps> = ({
  name, 
  value, 
  setValue, 
  label, 
  dataForm
}) => {
const cssDado = 'modelosdocumentosInput';
const { systemContext } = useSystemContext();
const modelosdocumentosService = new ModelosDocumentosService(
new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
);
const {
  options: filteredOptions, 
  loading, 
  selectedValue, 
  handleFilter, 
  handleValueChange, 
  clearValue
} = useModelosDocumentosComboBox(modelosdocumentosService);

const [isOpen, setIsOpen] = useState(false);
const [editRecord, setEditRecord] = useState<IModelosDocumentos | null>(null);
const [addRecord, setAddRecord] = useState<IModelosDocumentos | null>(null);
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
    const record = await modelosdocumentosService.fetchModelosDocumentosById(id);
    setEditRecord(record);
    setAction(ActionEditar);
    handleValueChange({ id: record.id, nome: record.nome });
  } catch (error) {
  console.log('Erro ao carregar Modelos Documentos:');
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
  const newRecord = ModelosDocumentosEmpty();
  newRecord.nome = inputValue.toUpperCase();
  setAddRecord(newRecord);
  setEditRecord(null);
  setIsOpen(true);
};

const handleClose = () => {
  setIsOpen(false);
  setAddRecord(null);
};
const handleSuccess = (newModelosDocumentos?: IModelosDocumentos) => {
  if (newModelosDocumentos) {
    setValue({ id: newModelosDocumentos.id, nome: newModelosDocumentos.nome });
    loadRecordForEdit(newModelosDocumentos.id);
    handleValueChange(newModelosDocumentos);
  }
  handleClose();
};
return (
<>
{(editRecord || addRecord) && isOpen && (
  <ModelosDocumentosWindow
  isOpen={isOpen}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleClose}
  selectedModelosDocumentos={editRecord || addRecord || ModelosDocumentosEmpty()}
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
export default ModelosDocumentosComboBox;