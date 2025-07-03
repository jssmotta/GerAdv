// Tracking: Forms.tsx.txt
'use client';
import { IProcessOutputEngine } from '@/app/GerAdv_TS/ProcessOutputEngine/Interfaces/interface.ProcessOutputEngine';
import { useRouter } from 'next/navigation';
import React, { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { ProcessOutputEngineApi } from '../../Apis/ApiProcessOutputEngine';
import { useValidationsProcessOutputEngine } from '../../Hooks/hookProcessOutputEngine';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface ProcessOutputEngineFormProps {
  processoutputengineData: IProcessOutputEngine;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProcessOutputEngineForm: React.FC<ProcessOutputEngineFormProps> = ({
  processoutputengineData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const { systemContext } = useSystemContext();
const isMobile = useIsMobile();
const dadoApi = new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProcessOutputEngine();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de ProcessOutputEngine:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  const handleCancel = () => {
    if (onReload) {
      onReload(); // Recarrega os dados originais
    } else {
    onClose(); // Comportamento padrão se não há callback de recarga
  }
};

const handleDirectSave = () => {
  if (!isSubmitting) {
    setIsSubmitting(true);

    try {
      const syntheticEvent = {
        preventDefault: () => { }, 
        target: document.getElementById(`ProcessOutputEngineForm-${processoutputengineData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar ProcessOutputEngine diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = processoutputengineData?.id == 0 ? 'Editar ProcessOutputEngine' : 'Adicionar Process Output Engine';
  }
}, [processoutputengineData.id]);
return (
<>
<style>
  {!isMobile ? `
    @media (max-width: 1366px) {
      html {
        zoom: 0.8 !important;
      }
    }
    ` : ``}
  </style>

  <div className={isMobile ? 'form-container form-container-ProcessOutputEngine' : 'form-container form-container-ProcessOutputEngine'}>

    <form className='formInputCadInc' id={`ProcessOutputEngineForm-${processoutputengineData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProcessOutputEngine' data={processoutputengineData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessOutputEngineForm-${processoutputengineData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='nome'
          value={processoutputengineData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

          <InputInput
          type='text'
          maxLength={255}
          id='database'
          label='Database'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='database'
          value={processoutputengineData.database}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={255}
          id='tabela'
          label='Tabela'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='tabela'
          value={processoutputengineData.tabela}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={255}
          id='campo'
          label='Campo'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='campo'
          value={processoutputengineData.campo}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={255}
          id='valor'
          label='Valor'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='valor'
          value={processoutputengineData.valor}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={2147483647}
          id='output'
          label='Output'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='output'
          value={processoutputengineData.output}
          onChange={onChange}
          />

          <InputCheckbox dataForm={processoutputengineData} label='Administrador' name='administrador' checked={processoutputengineData.administrador} onChange={onChange} />

          <InputInput
          type='text'
          maxLength={2048}
          id='outputsource'
          label='OutputSource'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='outputsource'
          value={processoutputengineData.outputsource}
          onChange={onChange}
          />

          <InputCheckbox dataForm={processoutputengineData} label='DisabledItem' name='disableditem' checked={processoutputengineData.disableditem} onChange={onChange} />
        </div><div className='grid-container'>
          <InputInput
          type='text'
          maxLength={2048}
          id='idmodulo'
          label='IDModulo'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='idmodulo'
          value={processoutputengineData.idmodulo}
          onChange={onChange}
          />

          <InputCheckbox dataForm={processoutputengineData} label='IsOnlyProcesso' name='isonlyprocesso' checked={processoutputengineData.isonlyprocesso} onChange={onChange} />

          <InputInput
          type='text'
          maxLength={2048}
          id='myid'
          label='MyID'
          dataForm={processoutputengineData}
          className='inputIncNome'
          name='myid'
          value={processoutputengineData.myid}
          onChange={onChange}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProcessOutputEngine' data={processoutputengineData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessOutputEngineForm-${processoutputengineData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/processoutputengine'} id={processoutputengineData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };