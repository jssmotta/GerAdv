// Tracking: Forms.tsx.txt
'use client';
import { IReuniaoPessoas } from '@/app/GerAdv_TS/ReuniaoPessoas/Interfaces/interface.ReuniaoPessoas';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { ReuniaoPessoasApi } from '../../Apis/ApiReuniaoPessoas';
import { useValidationsReuniaoPessoas } from '../../Hooks/hookReuniaoPessoas';
import ReuniaoComboBox from '@/app/GerAdv_TS/Reuniao/ComboBox/Reuniao';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ReuniaoApi } from '@/app/GerAdv_TS/Reuniao/Apis/ApiReuniao';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
interface ReuniaoPessoasFormProps {
  reuniaopessoasData: IReuniaoPessoas;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ReuniaoPessoasForm: React.FC<ReuniaoPessoasFormProps> = ({
  reuniaopessoasData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const isMobile = useIsMobile();
const { systemContext } = useSystemContext();
const dadoApi = new ReuniaoPessoasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsReuniaoPessoas();
const [nomeReuniao, setNomeReuniao] = useState('');
const reuniaoApi = new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('reuniao') > 0) {
  if (reuniaopessoasData.id === 0 && reuniaopessoasData.reuniao == 0) {
    reuniaoApi
    .getById(getParamFromUrl('reuniao'))
    .then((response) => {
      setNomeReuniao(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    reuniaopessoasData.reuniao = getParamFromUrl('reuniao');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (reuniaopessoasData.id === 0 && reuniaopessoasData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    reuniaopessoasData.operador = getParamFromUrl('operador');
  }
}
const addValorReuniao = (e: any) => {
  if (e?.id>0)
    reuniaopessoasData.reuniao = e.id;
  };
  const addValorOperador = (e: any) => {
    if (e?.id>0)
      reuniaopessoasData.operador = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de ReuniaoPessoas:', error);
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
            target: document.getElementById(`ReuniaoPessoasForm-${reuniaopessoasData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar ReuniaoPessoas diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = reuniaopessoasData?.id == 0 ? 'Editar ReuniaoPessoas' : 'Adicionar Reuniao Pessoas';
      }
    }, [reuniaopessoasData.id]);
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

      <div className={isMobile ? 'form-container form-container-ReuniaoPessoas' : 'form-container5 form-container-ReuniaoPessoas'}>

        <form className='formInputCadInc' id={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ReuniaoPessoas' data={reuniaopessoasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <ReuniaoComboBox
              name={'reuniao'}
              dataForm={reuniaopessoasData}
              value={reuniaopessoasData.reuniao}
              setValue={addValorReuniao}
              label={'Reuniao'}
              />

              <OperadorComboBox
              name={'operador'}
              dataForm={reuniaopessoasData}
              value={reuniaopessoasData.operador}
              setValue={addValorOperador}
              label={'Operador'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ReuniaoPessoas' data={reuniaopessoasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/reuniaopessoas'} id={reuniaopessoasData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };