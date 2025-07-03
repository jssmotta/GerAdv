// Tracking: Forms.tsx.txt
'use client';
import { IGraph } from '@/app/GerAdv_TS/Graph/Interfaces/interface.Graph';
import { useRouter } from 'next/navigation';
import React, { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { GraphApi } from '../../Apis/ApiGraph';
import { useValidationsGraph } from '../../Hooks/hookGraph';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface GraphFormProps {
  graphData: IGraph;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const GraphForm: React.FC<GraphFormProps> = ({
  graphData, 
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
const dadoApi = new GraphApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsGraph();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de Graph:', error);
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
        target: document.getElementById(`GraphForm-${graphData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar Graph diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = graphData?.id == 0 ? 'Editar Graph' : 'Adicionar Graph';
  }
}, [graphData.id]);
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

  <div className={isMobile ? 'form-container form-container-Graph' : 'form-container5 form-container-Graph'}>

    <form className='formInputCadInc' id={`GraphForm-${graphData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Graph' data={graphData} isSubmitting={isSubmitting} onClose={onClose} formId={`GraphForm-${graphData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>


          <InputInput
          type='text'
          maxLength={80}
          id='tabela'
          label='Tabela'
          dataForm={graphData}
          className='inputIncNome'
          name='tabela'
          value={graphData.tabela}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={2048}
          id='tabelaid'
          label='TabelaId'
          dataForm={graphData}
          className='inputIncNome'
          name='tabelaid'
          value={graphData.tabelaid}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={2048}
          id='imagem'
          label='Imagem'
          dataForm={graphData}
          className='inputIncNome'
          name='imagem'
          value={graphData.imagem}
          onChange={onChange}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Graph' data={graphData} isSubmitting={isSubmitting} onClose={onClose} formId={`GraphForm-${graphData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/graph'} id={graphData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };