// Tracking: Forms.tsx.txt
'use client';
import { IParceriaProc } from '@/app/GerAdv_TS/ParceriaProc/Interfaces/interface.ParceriaProc';
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
import { ParceriaProcApi } from '../../Apis/ApiParceriaProc';
import { useValidationsParceriaProc } from '../../Hooks/hookParceriaProc';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
interface ParceriaProcFormProps {
  parceriaprocData: IParceriaProc;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ParceriaProcForm: React.FC<ParceriaProcFormProps> = ({
  parceriaprocData, 
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
const dadoApi = new ParceriaProcApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsParceriaProc();
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('advogados') > 0) {
  if (parceriaprocData.id === 0 && parceriaprocData.advogado == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    parceriaprocData.advogado = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (parceriaprocData.id === 0 && parceriaprocData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    parceriaprocData.processo = getParamFromUrl('processos');
  }
}
const addValorAdvogado = (e: any) => {
  if (e?.id>0)
    parceriaprocData.advogado = e.id;
  };
  const addValorProcesso = (e: any) => {
    if (e?.id>0)
      parceriaprocData.processo = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de ParceriaProc:', error);
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
            target: document.getElementById(`ParceriaProcForm-${parceriaprocData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar ParceriaProc diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = parceriaprocData?.id == 0 ? 'Editar ParceriaProc' : 'Adicionar Parceria Proc';
      }
    }, [parceriaprocData.id]);
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

      <div className={isMobile ? 'form-container form-container-ParceriaProc' : 'form-container5 form-container-ParceriaProc'}>

        <form className='formInputCadInc' id={`ParceriaProcForm-${parceriaprocData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ParceriaProc' data={parceriaprocData} isSubmitting={isSubmitting} onClose={onClose} formId={`ParceriaProcForm-${parceriaprocData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <AdvogadosComboBox
              name={'advogado'}
              dataForm={parceriaprocData}
              value={parceriaprocData.advogado}
              setValue={addValorAdvogado}
              label={'Advogados'}
              />

              <ProcessosComboBox
              name={'processo'}
              dataForm={parceriaprocData}
              value={parceriaprocData.processo}
              setValue={addValorProcesso}
              label={'Processos'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ParceriaProc' data={parceriaprocData} isSubmitting={isSubmitting} onClose={onClose} formId={`ParceriaProcForm-${parceriaprocData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/parceriaproc'} id={parceriaprocData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };