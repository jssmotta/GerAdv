// Tracking: Forms.tsx.txt
'use client';
import { ISMSAlice } from '@/app/GerAdv_TS/SMSAlice/Interfaces/interface.SMSAlice';
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
import { SMSAliceApi } from '../../Apis/ApiSMSAlice';
import { useValidationsSMSAlice } from '../../Hooks/hookSMSAlice';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import TipoEMailComboBox from '@/app/GerAdv_TS/TipoEMail/ComboBox/TipoEMail';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { TipoEMailApi } from '@/app/GerAdv_TS/TipoEMail/Apis/ApiTipoEMail';
import InputName from '@/app/components/Inputs/InputName';
interface SMSAliceFormProps {
  smsaliceData: ISMSAlice;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const SMSAliceForm: React.FC<SMSAliceFormProps> = ({
  smsaliceData, 
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
const dadoApi = new SMSAliceApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsSMSAlice();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoEMail, setNomeTipoEMail] = useState('');
const tipoemailApi = new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (smsaliceData.id === 0 && smsaliceData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    smsaliceData.operador = getParamFromUrl('operador');
  }
}

if (getParamFromUrl('tipoemail') > 0) {
  if (smsaliceData.id === 0 && smsaliceData.tipoemail == 0) {
    tipoemailApi
    .getById(getParamFromUrl('tipoemail'))
    .then((response) => {
      setNomeTipoEMail(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    smsaliceData.tipoemail = getParamFromUrl('tipoemail');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    smsaliceData.operador = e.id;
  };
  const addValorTipoEMail = (e: any) => {
    if (e?.id>0)
      smsaliceData.tipoemail = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de SMSAlice:', error);
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
            target: document.getElementById(`SMSAliceForm-${smsaliceData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar SMSAlice diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = smsaliceData?.id == 0 ? 'Editar SMSAlice' : 'Adicionar S M S Alice';
      }
    }, [smsaliceData.id]);
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

      <div className={isMobile ? 'form-container form-container-SMSAlice' : 'form-container5 form-container-SMSAlice'}>

        <form className='formInputCadInc' id={`SMSAliceForm-${smsaliceData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='SMSAlice' data={smsaliceData} isSubmitting={isSubmitting} onClose={onClose} formId={`SMSAliceForm-${smsaliceData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputName
              type='text'
              id='nome'
              label='Nome'
              dataForm={smsaliceData}
              className='inputIncNome'
              name='nome'
              value={smsaliceData.nome}
              placeholder={`Informe Nome`}
              onChange={onChange}
              required
              />

              <OperadorComboBox
              name={'operador'}
              dataForm={smsaliceData}
              value={smsaliceData.operador}
              setValue={addValorOperador}
              label={'Operador'}
              />

              <TipoEMailComboBox
              name={'tipoemail'}
              dataForm={smsaliceData}
              value={smsaliceData.tipoemail}
              setValue={addValorTipoEMail}
              label={'Tipo E Mail'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='SMSAlice' data={smsaliceData} isSubmitting={isSubmitting} onClose={onClose} formId={`SMSAliceForm-${smsaliceData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/smsalice'} id={smsaliceData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };