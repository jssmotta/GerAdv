// Tracking: Forms.tsx.txt
'use client';
import { IProcessOutputRequest } from '@/app/GerAdv_TS/ProcessOutputRequest/Interfaces/interface.ProcessOutputRequest';
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
import { ProcessOutputRequestApi } from '../../Apis/ApiProcessOutputRequest';
import { useValidationsProcessOutputRequest } from '../../Hooks/hookProcessOutputRequest';
import ProcessOutputEngineComboBox from '@/app/GerAdv_TS/ProcessOutputEngine/ComboBox/ProcessOutputEngine';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessOutputEngineApi } from '@/app/GerAdv_TS/ProcessOutputEngine/Apis/ApiProcessOutputEngine';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ProcessOutputRequestFormProps {
  processoutputrequestData: IProcessOutputRequest;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProcessOutputRequestForm: React.FC<ProcessOutputRequestFormProps> = ({
  processoutputrequestData, 
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
const dadoApi = new ProcessOutputRequestApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProcessOutputRequest();
const [nomeProcessOutputEngine, setNomeProcessOutputEngine] = useState('');
const processoutputengineApi = new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processoutputengine') > 0) {
  if (processoutputrequestData.id === 0 && processoutputrequestData.processoutputengine == 0) {
    processoutputengineApi
    .getById(getParamFromUrl('processoutputengine'))
    .then((response) => {
      setNomeProcessOutputEngine(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processoutputrequestData.processoutputengine = getParamFromUrl('processoutputengine');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (processoutputrequestData.id === 0 && processoutputrequestData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    processoutputrequestData.operador = getParamFromUrl('operador');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (processoutputrequestData.id === 0 && processoutputrequestData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    processoutputrequestData.processo = getParamFromUrl('processos');
  }
}
const addValorProcessOutputEngine = (e: any) => {
  if (e?.id>0)
    processoutputrequestData.processoutputengine = e.id;
  };
  const addValorOperador = (e: any) => {
    if (e?.id>0)
      processoutputrequestData.operador = e.id;
    };
    const addValorProcesso = (e: any) => {
      if (e?.id>0)
        processoutputrequestData.processo = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de ProcessOutputRequest:', error);
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
              target: document.getElementById(`ProcessOutputRequestForm-${processoutputrequestData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar ProcessOutputRequest diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = processoutputrequestData?.id == 0 ? 'Editar ProcessOutputRequest' : 'Adicionar Process Output Request';
        }
      }, [processoutputrequestData.id]);
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

        <div className={isMobile ? 'form-container form-container-ProcessOutputRequest' : 'form-container5 form-container-ProcessOutputRequest'}>

          <form className='formInputCadInc' id={`ProcessOutputRequestForm-${processoutputrequestData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProcessOutputRequest' data={processoutputrequestData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessOutputRequestForm-${processoutputrequestData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>


                <ProcessOutputEngineComboBox
                name={'processoutputengine'}
                dataForm={processoutputrequestData}
                value={processoutputrequestData.processoutputengine}
                setValue={addValorProcessOutputEngine}
                label={'Process Output Engine'}
                />

                <OperadorComboBox
                name={'operador'}
                dataForm={processoutputrequestData}
                value={processoutputrequestData.operador}
                setValue={addValorOperador}
                label={'Operador'}
                />

                <ProcessosComboBox
                name={'processo'}
                dataForm={processoutputrequestData}
                value={processoutputrequestData.processo}
                setValue={addValorProcesso}
                label={'Processos'}
                />

                <InputInput
                type='text'
                maxLength={2048}
                id='ultimoidtabelaexo'
                label='UltimoIdTabelaExo'
                dataForm={processoutputrequestData}
                className='inputIncNome'
                name='ultimoidtabelaexo'
                value={processoutputrequestData.ultimoidtabelaexo}
                onChange={onChange}
                />

              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProcessOutputRequest' data={processoutputrequestData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessOutputRequestForm-${processoutputrequestData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/processoutputrequest'} id={processoutputrequestData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };