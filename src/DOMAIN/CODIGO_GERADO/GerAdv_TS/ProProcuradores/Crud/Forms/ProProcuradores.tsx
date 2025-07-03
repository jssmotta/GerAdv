// Tracking: Forms.tsx.txt
'use client';
import { IProProcuradores } from '@/app/GerAdv_TS/ProProcuradores/Interfaces/interface.ProProcuradores';
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
import { ProProcuradoresApi } from '../../Apis/ApiProProcuradores';
import { useValidationsProProcuradores } from '../../Hooks/hookProProcuradores';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface ProProcuradoresFormProps {
  proprocuradoresData: IProProcuradores;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProProcuradoresForm: React.FC<ProProcuradoresFormProps> = ({
  proprocuradoresData, 
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
const dadoApi = new ProProcuradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProProcuradores();
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('advogados') > 0) {
  if (proprocuradoresData.id === 0 && proprocuradoresData.advogado == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    proprocuradoresData.advogado = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (proprocuradoresData.id === 0 && proprocuradoresData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    proprocuradoresData.processo = getParamFromUrl('processos');
  }
}
const addValorAdvogado = (e: any) => {
  if (e?.id>0)
    proprocuradoresData.advogado = e.id;
  };
  const addValorProcesso = (e: any) => {
    if (e?.id>0)
      proprocuradoresData.processo = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de ProProcuradores:', error);
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
            target: document.getElementById(`ProProcuradoresForm-${proprocuradoresData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar ProProcuradores diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = proprocuradoresData?.id == 0 ? 'Editar ProProcuradores' : 'Adicionar Pro Procuradores';
      }
    }, [proprocuradoresData.id]);
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

      <div className={isMobile ? 'form-container form-container-ProProcuradores' : 'form-container5 form-container-ProProcuradores'}>

        <form className='formInputCadInc' id={`ProProcuradoresForm-${proprocuradoresData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProProcuradores' data={proprocuradoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProProcuradoresForm-${proprocuradoresData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputName
              type='text'
              id='nome'
              label='Nome'
              dataForm={proprocuradoresData}
              className='inputIncNome'
              name='nome'
              value={proprocuradoresData.nome}
              placeholder={`Informe Nome`}
              onChange={onChange}
              required
              />

              <AdvogadosComboBox
              name={'advogado'}
              dataForm={proprocuradoresData}
              value={proprocuradoresData.advogado}
              setValue={addValorAdvogado}
              label={'Advogados'}
              />

              <ProcessosComboBox
              name={'processo'}
              dataForm={proprocuradoresData}
              value={proprocuradoresData.processo}
              setValue={addValorProcesso}
              label={'Processos'}
              />

              <InputInput
              type='text'
              maxLength={2048}
              id='data'
              label='Data'
              dataForm={proprocuradoresData}
              className='inputIncNome'
              name='data'
              value={proprocuradoresData.data}
              onChange={onChange}
              />

              <InputCheckbox dataForm={proprocuradoresData} label='Substabelecimento' name='substabelecimento' checked={proprocuradoresData.substabelecimento} onChange={onChange} />
              <InputCheckbox dataForm={proprocuradoresData} label='Procuracao' name='procuracao' checked={proprocuradoresData.procuracao} onChange={onChange} />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProProcuradores' data={proprocuradoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProProcuradoresForm-${proprocuradoresData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/proprocuradores'} id={proprocuradoresData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };