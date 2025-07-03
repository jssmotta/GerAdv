// Tracking: Forms.tsx.txt
'use client';
import { IAgendaRelatorio } from '@/app/GerAdv_TS/AgendaRelatorio/Interfaces/interface.AgendaRelatorio';
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
import { AgendaRelatorioApi } from '../../Apis/ApiAgendaRelatorio';
import { useValidationsAgendaRelatorio } from '../../Hooks/hookAgendaRelatorio';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface AgendaRelatorioFormProps {
  agendarelatorioData: IAgendaRelatorio;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AgendaRelatorioForm: React.FC<AgendaRelatorioFormProps> = ({
  agendarelatorioData, 
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
const dadoApi = new AgendaRelatorioApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgendaRelatorio();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (agendarelatorioData.id === 0 && agendarelatorioData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    agendarelatorioData.processo = getParamFromUrl('processos');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    agendarelatorioData.processo = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de AgendaRelatorio:', error);
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
          target: document.getElementById(`AgendaRelatorioForm-${agendarelatorioData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar AgendaRelatorio diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = agendarelatorioData?.id == 0 ? 'Editar AgendaRelatorio' : 'Adicionar Agenda Relatorio';
    }
  }, [agendarelatorioData.id]);
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

    <div className={isMobile ? 'form-container form-container-AgendaRelatorio' : 'form-container form-container-AgendaRelatorio'}>

      <form className='formInputCadInc' id={`AgendaRelatorioForm-${agendarelatorioData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AgendaRelatorio' data={agendarelatorioData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRelatorioForm-${agendarelatorioData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='campo'
            label='advNome'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='campo'
            value={agendarelatorioData.campo}
            placeholder={`Informe advNome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='data'
            label='Data'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='data'
            value={agendarelatorioData.data}
            onChange={onChange}
            />


            <ProcessosComboBox
            name={'processo'}
            dataForm={agendarelatorioData}
            value={agendarelatorioData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <InputInput
            type='text'
            maxLength={60}
            id='paranome'
            label='ParaNome'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='paranome'
            value={agendarelatorioData.paranome}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='parapessoas'
            label='ParaPessoas'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='parapessoas'
            value={agendarelatorioData.parapessoas}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='boxaudiencia'
            label='BoxAudiencia'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='boxaudiencia'
            value={agendarelatorioData.boxaudiencia}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='boxaudienciamobile'
            label='BoxAudienciaMobile'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='boxaudienciamobile'
            value={agendarelatorioData.boxaudienciamobile}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={50}
            id='nomeadvogado'
            label='NomeAdvogado'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='nomeadvogado'
            value={agendarelatorioData.nomeadvogado}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={40}
            id='nomeforo'
            label='NomeForo'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='nomeforo'
            value={agendarelatorioData.nomeforo}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputInput
            type='text'
            maxLength={50}
            id='nomejustica'
            label='NomeJustica'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='nomejustica'
            value={agendarelatorioData.nomejustica}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={40}
            id='nomearea'
            label='NomeArea'
            dataForm={agendarelatorioData}
            className='inputIncNome'
            name='nomearea'
            value={agendarelatorioData.nomearea}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AgendaRelatorio' data={agendarelatorioData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRelatorioForm-${agendarelatorioData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/agendarelatorio'} id={agendarelatorioData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };