// Tracking: Forms.tsx.txt
'use client';
import { IOperadorGruposAgendaOperadores } from '@/app/GerAdv_TS/OperadorGruposAgendaOperadores/Interfaces/interface.OperadorGruposAgendaOperadores';
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
import { OperadorGruposAgendaOperadoresApi } from '../../Apis/ApiOperadorGruposAgendaOperadores';
import { useValidationsOperadorGruposAgendaOperadores } from '../../Hooks/hookOperadorGruposAgendaOperadores';
import OperadorGruposAgendaComboBox from '@/app/GerAdv_TS/OperadorGruposAgenda/ComboBox/OperadorGruposAgenda';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorGruposAgendaApi } from '@/app/GerAdv_TS/OperadorGruposAgenda/Apis/ApiOperadorGruposAgenda';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
interface OperadorGruposAgendaOperadoresFormProps {
  operadorgruposagendaoperadoresData: IOperadorGruposAgendaOperadores;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const OperadorGruposAgendaOperadoresForm: React.FC<OperadorGruposAgendaOperadoresFormProps> = ({
  operadorgruposagendaoperadoresData, 
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
const dadoApi = new OperadorGruposAgendaOperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsOperadorGruposAgendaOperadores();
const [nomeOperadorGruposAgenda, setNomeOperadorGruposAgenda] = useState('');
const operadorgruposagendaApi = new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operadorgruposagenda') > 0) {
  if (operadorgruposagendaoperadoresData.id === 0 && operadorgruposagendaoperadoresData.operadorgruposagenda == 0) {
    operadorgruposagendaApi
    .getById(getParamFromUrl('operadorgruposagenda'))
    .then((response) => {
      setNomeOperadorGruposAgenda(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    operadorgruposagendaoperadoresData.operadorgruposagenda = getParamFromUrl('operadorgruposagenda');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (operadorgruposagendaoperadoresData.id === 0 && operadorgruposagendaoperadoresData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    operadorgruposagendaoperadoresData.operador = getParamFromUrl('operador');
  }
}
const addValorOperadorGruposAgenda = (e: any) => {
  if (e?.id>0)
    operadorgruposagendaoperadoresData.operadorgruposagenda = e.id;
  };
  const addValorOperador = (e: any) => {
    if (e?.id>0)
      operadorgruposagendaoperadoresData.operador = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de OperadorGruposAgendaOperadores:', error);
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
            target: document.getElementById(`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar OperadorGruposAgendaOperadores diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = operadorgruposagendaoperadoresData?.id == 0 ? 'Editar OperadorGruposAgendaOperadores' : 'Adicionar Operador Grupos Agenda Operadores';
      }
    }, [operadorgruposagendaoperadoresData.id]);
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

      <div className={isMobile ? 'form-container form-container-OperadorGruposAgendaOperadores' : 'form-container5 form-container-OperadorGruposAgendaOperadores'}>

        <form className='formInputCadInc' id={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='OperadorGruposAgendaOperadores' data={operadorgruposagendaoperadoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <OperadorGruposAgendaComboBox
              name={'operadorgruposagenda'}
              dataForm={operadorgruposagendaoperadoresData}
              value={operadorgruposagendaoperadoresData.operadorgruposagenda}
              setValue={addValorOperadorGruposAgenda}
              label={'Operador Grupos Agenda'}
              />

              <OperadorComboBox
              name={'operador'}
              dataForm={operadorgruposagendaoperadoresData}
              value={operadorgruposagendaoperadoresData.operador}
              setValue={addValorOperador}
              label={'Operador'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='OperadorGruposAgendaOperadores' data={operadorgruposagendaoperadoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/operadorgruposagendaoperadores'} id={operadorgruposagendaoperadoresData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };