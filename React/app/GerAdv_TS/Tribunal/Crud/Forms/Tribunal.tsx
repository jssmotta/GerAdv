// Tracking: Forms.tsx.txt
'use client';
import { ITribunal } from '@/app/GerAdv_TS/Tribunal/Interfaces/interface.Tribunal';
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
import { TribunalApi } from '../../Apis/ApiTribunal';
import { useValidationsTribunal } from '../../Hooks/hookTribunal';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import InstanciaComboBox from '@/app/GerAdv_TS/Instancia/ComboBox/Instancia';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { InstanciaApi } from '@/app/GerAdv_TS/Instancia/Apis/ApiInstancia';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface TribunalFormProps {
  tribunalData: ITribunal;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TribunalForm: React.FC<TribunalFormProps> = ({
  tribunalData, 
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
const dadoApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTribunal();
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeInstancia, setNomeInstancia] = useState('');
const instanciaApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('area') > 0) {
  if (tribunalData.id === 0 && tribunalData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    tribunalData.area = getParamFromUrl('area');
  }
}

if (getParamFromUrl('justica') > 0) {
  if (tribunalData.id === 0 && tribunalData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    tribunalData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('instancia') > 0) {
  if (tribunalData.id === 0 && tribunalData.instancia == 0) {
    instanciaApi
    .getById(getParamFromUrl('instancia'))
    .then((response) => {
      setNomeInstancia(response.data.nroprocesso);
    })
    .catch((error) => {
      console.error(error);
    });

    tribunalData.instancia = getParamFromUrl('instancia');
  }
}
const addValorArea = (e: any) => {
  if (e?.id>0)
    tribunalData.area = e.id;
  };
  const addValorJustica = (e: any) => {
    if (e?.id>0)
      tribunalData.justica = e.id;
    };
    const addValorInstancia = (e: any) => {
      if (e?.id>0)
        tribunalData.instancia = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de Tribunal:', error);
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
              target: document.getElementById(`TribunalForm-${tribunalData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar Tribunal diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = tribunalData?.id == 0 ? 'Editar Tribunal' : 'Adicionar Tribunal';
        }
      }, [tribunalData.id]);
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

        <div className={isMobile ? 'form-container form-container-Tribunal' : 'form-container5 form-container-Tribunal'}>

          <form className='formInputCadInc' id={`TribunalForm-${tribunalData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Tribunal' data={tribunalData} isSubmitting={isSubmitting} onClose={onClose} formId={`TribunalForm-${tribunalData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>

                <InputName
                type='text'
                id='nome'
                label='Nome'
                dataForm={tribunalData}
                className='inputIncNome'
                name='nome'
                value={tribunalData.nome}
                placeholder={`Informe Nome`}
                onChange={onChange}
                required
                />

                <AreaComboBox
                name={'area'}
                dataForm={tribunalData}
                value={tribunalData.area}
                setValue={addValorArea}
                label={'Area'}
                />

                <JusticaComboBox
                name={'justica'}
                dataForm={tribunalData}
                value={tribunalData.justica}
                setValue={addValorJustica}
                label={'Justica'}
                />

                <InputInput
                type='text'
                maxLength={50}
                id='descricao'
                label='Descricao'
                dataForm={tribunalData}
                className='inputIncNome'
                name='descricao'
                value={tribunalData.descricao}
                onChange={onChange}
                />


                <InstanciaComboBox
                name={'instancia'}
                dataForm={tribunalData}
                value={tribunalData.instancia}
                setValue={addValorInstancia}
                label={'Instancia'}
                />

                <InputInput
                type='text'
                maxLength={20}
                id='sigla'
                label='Sigla'
                dataForm={tribunalData}
                className='inputIncNome'
                name='sigla'
                value={tribunalData.sigla}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={255}
                id='web'
                label='Web'
                dataForm={tribunalData}
                className='inputIncNome'
                name='web'
                value={tribunalData.web}
                onChange={onChange}
                />

              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Tribunal' data={tribunalData} isSubmitting={isSubmitting} onClose={onClose} formId={`TribunalForm-${tribunalData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/tribunal'} id={tribunalData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };