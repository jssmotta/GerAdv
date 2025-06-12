// Tracking: Forms.tsx.txt
'use client';
import { IAlertasEnviados } from '@/app/GerAdv_TS/AlertasEnviados/Interfaces/interface.AlertasEnviados';
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
import { AlertasEnviadosApi } from '../../Apis/ApiAlertasEnviados';
import { useValidationsAlertasEnviados } from '../../Hooks/hookAlertasEnviados';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import AlertasComboBox from '@/app/GerAdv_TS/Alertas/ComboBox/Alertas';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { AlertasApi } from '@/app/GerAdv_TS/Alertas/Apis/ApiAlertas';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface AlertasEnviadosFormProps {
  alertasenviadosData: IAlertasEnviados;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AlertasEnviadosForm: React.FC<AlertasEnviadosFormProps> = ({
  alertasenviadosData, 
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
const dadoApi = new AlertasEnviadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAlertasEnviados();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAlertas, setNomeAlertas] = useState('');
const alertasApi = new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (alertasenviadosData.id === 0 && alertasenviadosData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    alertasenviadosData.operador = getParamFromUrl('operador');
  }
}

if (getParamFromUrl('alertas') > 0) {
  if (alertasenviadosData.id === 0 && alertasenviadosData.alerta == 0) {
    alertasApi
    .getById(getParamFromUrl('alertas'))
    .then((response) => {
      setNomeAlertas(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    alertasenviadosData.alerta = getParamFromUrl('alertas');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    alertasenviadosData.operador = e.id;
  };
  const addValorAlerta = (e: any) => {
    if (e?.id>0)
      alertasenviadosData.alerta = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de AlertasEnviados:', error);
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
            target: document.getElementById(`AlertasEnviadosForm-${alertasenviadosData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar AlertasEnviados diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = alertasenviadosData?.id == 0 ? 'Editar AlertasEnviados' : 'Adicionar Alertas Enviados';
      }
    }, [alertasenviadosData.id]);
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

      <div className={isMobile ? 'form-container form-container-AlertasEnviados' : 'form-container5 form-container-AlertasEnviados'}>

        <form className='formInputCadInc' id={`AlertasEnviadosForm-${alertasenviadosData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AlertasEnviados' data={alertasenviadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AlertasEnviadosForm-${alertasenviadosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <OperadorComboBox
              name={'operador'}
              dataForm={alertasenviadosData}
              value={alertasenviadosData.operador}
              setValue={addValorOperador}
              label={'Operador'}
              />

              <AlertasComboBox
              name={'alerta'}
              dataForm={alertasenviadosData}
              value={alertasenviadosData.alerta}
              setValue={addValorAlerta}
              label={'Alertas'}
              />

              <InputInput
              type='text'
              maxLength={2048}
              id='dataalertado'
              label='DataAlertado'
              dataForm={alertasenviadosData}
              className='inputIncNome'
              name='dataalertado'
              value={alertasenviadosData.dataalertado}
              onChange={onChange}
              />

              <InputCheckbox dataForm={alertasenviadosData} label='Visualizado' name='visualizado' checked={alertasenviadosData.visualizado} onChange={onChange} />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AlertasEnviados' data={alertasenviadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AlertasEnviadosForm-${alertasenviadosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/alertasenviados'} id={alertasenviadosData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };