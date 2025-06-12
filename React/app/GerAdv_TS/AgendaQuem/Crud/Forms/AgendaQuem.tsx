// Tracking: Forms.tsx.txt
'use client';
import { IAgendaQuem } from '@/app/GerAdv_TS/AgendaQuem/Interfaces/interface.AgendaQuem';
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
import { AgendaQuemApi } from '../../Apis/ApiAgendaQuem';
import { useValidationsAgendaQuem } from '../../Hooks/hookAgendaQuem';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface AgendaQuemFormProps {
  agendaquemData: IAgendaQuem;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AgendaQuemForm: React.FC<AgendaQuemFormProps> = ({
  agendaquemData, 
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
const dadoApi = new AgendaQuemApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgendaQuem();
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('advogados') > 0) {
  if (agendaquemData.id === 0 && agendaquemData.advogado == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaquemData.advogado = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('funcionarios') > 0) {
  if (agendaquemData.id === 0 && agendaquemData.funcionario == 0) {
    funcionariosApi
    .getById(getParamFromUrl('funcionarios'))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaquemData.funcionario = getParamFromUrl('funcionarios');
  }
}

if (getParamFromUrl('prepostos') > 0) {
  if (agendaquemData.id === 0 && agendaquemData.preposto == 0) {
    prepostosApi
    .getById(getParamFromUrl('prepostos'))
    .then((response) => {
      setNomePrepostos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaquemData.preposto = getParamFromUrl('prepostos');
  }
}
const addValorAdvogado = (e: any) => {
  if (e?.id>0)
    agendaquemData.advogado = e.id;
  };
  const addValorFuncionario = (e: any) => {
    if (e?.id>0)
      agendaquemData.funcionario = e.id;
    };
    const addValorPreposto = (e: any) => {
      if (e?.id>0)
        agendaquemData.preposto = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de AgendaQuem:', error);
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
              target: document.getElementById(`AgendaQuemForm-${agendaquemData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar AgendaQuem diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = agendaquemData?.id == 0 ? 'Editar AgendaQuem' : 'Adicionar Agenda Quem';
        }
      }, [agendaquemData.id]);
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

        <div className={isMobile ? 'form-container form-container-AgendaQuem' : 'form-container5 form-container-AgendaQuem'}>

          <form className='formInputCadInc' id={`AgendaQuemForm-${agendaquemData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AgendaQuem' data={agendaquemData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaQuemForm-${agendaquemData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>


                <InputInput
                type='text'
                maxLength={2048}
                id='idagenda'
                label='IDAgenda'
                dataForm={agendaquemData}
                className='inputIncNome'
                name='idagenda'
                value={agendaquemData.idagenda}
                onChange={onChange}
                />


                <AdvogadosComboBox
                name={'advogado'}
                dataForm={agendaquemData}
                value={agendaquemData.advogado}
                setValue={addValorAdvogado}
                label={'Advogados'}
                />

                <FuncionariosComboBox
                name={'funcionario'}
                dataForm={agendaquemData}
                value={agendaquemData.funcionario}
                setValue={addValorFuncionario}
                label={'Colaborador'}
                />

                <PrepostosComboBox
                name={'preposto'}
                dataForm={agendaquemData}
                value={agendaquemData.preposto}
                setValue={addValorPreposto}
                label={'Prepostos'}
                />
              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AgendaQuem' data={agendaquemData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaQuemForm-${agendaquemData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/agendaquem'} id={agendaquemData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };