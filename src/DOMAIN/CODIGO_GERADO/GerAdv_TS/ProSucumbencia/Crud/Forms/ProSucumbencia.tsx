// Tracking: Forms.tsx.txt
'use client';
import { IProSucumbencia } from '@/app/GerAdv_TS/ProSucumbencia/Interfaces/interface.ProSucumbencia';
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
import { ProSucumbenciaApi } from '../../Apis/ApiProSucumbencia';
import { useValidationsProSucumbencia } from '../../Hooks/hookProSucumbencia';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import TipoOrigemSucumbenciaComboBox from '@/app/GerAdv_TS/TipoOrigemSucumbencia/ComboBox/TipoOrigemSucumbencia';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';
import { TipoOrigemSucumbenciaApi } from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Apis/ApiTipoOrigemSucumbencia';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ProSucumbenciaFormProps {
  prosucumbenciaData: IProSucumbencia;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProSucumbenciaForm: React.FC<ProSucumbenciaFormProps> = ({
  prosucumbenciaData, 
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
const dadoApi = new ProSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProSucumbencia();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeInstancia, setNomeInstancia] = useState('');
const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoOrigemSucumbencia, setNomeTipoOrigemSucumbencia] = useState('');
const tipoorigemsucumbenciaApi = new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (prosucumbenciaData.id === 0 && prosucumbenciaData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    prosucumbenciaData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('instancia') > 0) {
  if (prosucumbenciaData.id === 0 && prosucumbenciaData.instancia == 0) {
    instanciaApi
    .getById(getParamFromUrl('instancia'))
    .then((response) => {
      setNomeInstancia(response.data.nroprocesso);
    })
    .catch((error) => {
      console.error(error);
    });

    prosucumbenciaData.instancia = getParamFromUrl('instancia');
  }
}

if (getParamFromUrl('tipoorigemsucumbencia') > 0) {
  if (prosucumbenciaData.id === 0 && prosucumbenciaData.tipoorigemsucumbencia == 0) {
    tipoorigemsucumbenciaApi
    .getById(getParamFromUrl('tipoorigemsucumbencia'))
    .then((response) => {
      setNomeTipoOrigemSucumbencia(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    prosucumbenciaData.tipoorigemsucumbencia = getParamFromUrl('tipoorigemsucumbencia');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    prosucumbenciaData.processo = e.id;
  };
  const addValorInstancia = (e: any) => {
    if (e?.id>0)
      prosucumbenciaData.instancia = e.id;
    };
    const addValorTipoOrigemSucumbencia = (e: any) => {
      if (e?.id>0)
        prosucumbenciaData.tipoorigemsucumbencia = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de ProSucumbencia:', error);
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
              target: document.getElementById(`ProSucumbenciaForm-${prosucumbenciaData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar ProSucumbencia diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = prosucumbenciaData?.id == 0 ? 'Editar ProSucumbencia' : 'Adicionar Pro Sucumbencia';
        }
      }, [prosucumbenciaData.id]);
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

        <div className={isMobile ? 'form-container form-container-ProSucumbencia' : 'form-container5 form-container-ProSucumbencia'}>

          <form className='formInputCadInc' id={`ProSucumbenciaForm-${prosucumbenciaData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProSucumbencia' data={prosucumbenciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProSucumbenciaForm-${prosucumbenciaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>

                <InputName
                type='text'
                id='nome'
                label='Nome'
                dataForm={prosucumbenciaData}
                className='inputIncNome'
                name='nome'
                value={prosucumbenciaData.nome}
                placeholder={`Informe Nome`}
                onChange={onChange}
                required
                />

                <ProcessosComboBox
                name={'processo'}
                dataForm={prosucumbenciaData}
                value={prosucumbenciaData.processo}
                setValue={addValorProcesso}
                label={'Processos'}
                />

                <InstanciaComboBox
                name={'instancia'}
                dataForm={prosucumbenciaData}
                value={prosucumbenciaData.instancia}
                setValue={addValorInstancia}
                label={'Instancia'}
                />

                <InputInput
                type='text'
                maxLength={2048}
                id='data'
                label='Data'
                dataForm={prosucumbenciaData}
                className='inputIncNome'
                name='data'
                value={prosucumbenciaData.data}
                onChange={onChange}
                />


                <TipoOrigemSucumbenciaComboBox
                name={'tipoorigemsucumbencia'}
                dataForm={prosucumbenciaData}
                value={prosucumbenciaData.tipoorigemsucumbencia}
                setValue={addValorTipoOrigemSucumbencia}
                label={'Tipo Origem Sucumbencia'}
                />

                <InputInput
                type='text'
                maxLength={2048}
                id='valor'
                label='Valor'
                dataForm={prosucumbenciaData}
                className='inputIncNome'
                name='valor'
                value={prosucumbenciaData.valor}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={5}
                id='percentual'
                label='Percentual'
                dataForm={prosucumbenciaData}
                className='inputIncNome'
                name='percentual'
                value={prosucumbenciaData.percentual}
                onChange={onChange}
                />

              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProSucumbencia' data={prosucumbenciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProSucumbenciaForm-${prosucumbenciaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/prosucumbencia'} id={prosucumbenciaData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };