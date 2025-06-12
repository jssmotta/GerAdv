// Tracking: Forms.tsx.txt
'use client';
import { IProcessosObsReport } from '@/app/GerAdv_TS/ProcessosObsReport/Interfaces/interface.ProcessosObsReport';
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
import { ProcessosObsReportApi } from '../../Apis/ApiProcessosObsReport';
import { useValidationsProcessosObsReport } from '../../Hooks/hookProcessosObsReport';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import HistoricoComboBox from '@/app/GerAdv_TS/Historico/ComboBox/Historico';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { HistoricoApi } from '@/app/GerAdv_TS/Historico/Apis/ApiHistorico';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ProcessosObsReportFormProps {
  processosobsreportData: IProcessosObsReport;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProcessosObsReportForm: React.FC<ProcessosObsReportFormProps> = ({
  processosobsreportData, 
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
const dadoApi = new ProcessosObsReportApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProcessosObsReport();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeHistorico, setNomeHistorico] = useState('');
const historicoApi = new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (processosobsreportData.id === 0 && processosobsreportData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    processosobsreportData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('historico') > 0) {
  if (processosobsreportData.id === 0 && processosobsreportData.historico == 0) {
    historicoApi
    .getById(getParamFromUrl('historico'))
    .then((response) => {
      setNomeHistorico(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    processosobsreportData.historico = getParamFromUrl('historico');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    processosobsreportData.processo = e.id;
  };
  const addValorHistorico = (e: any) => {
    if (e?.id>0)
      processosobsreportData.historico = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de ProcessosObsReport:', error);
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
            target: document.getElementById(`ProcessosObsReportForm-${processosobsreportData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar ProcessosObsReport diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = processosobsreportData?.id == 0 ? 'Editar ProcessosObsReport' : 'Adicionar Processos Obs Report';
      }
    }, [processosobsreportData.id]);
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

      <div className={isMobile ? 'form-container form-container-ProcessosObsReport' : 'form-container5 form-container-ProcessosObsReport'}>

        <form className='formInputCadInc' id={`ProcessosObsReportForm-${processosobsreportData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProcessosObsReport' data={processosobsreportData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosObsReportForm-${processosobsreportData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <InputInput
              type='text'
              maxLength={2048}
              id='data'
              label='Data'
              dataForm={processosobsreportData}
              className='inputIncNome'
              name='data'
              value={processosobsreportData.data}
              onChange={onChange}
              />


              <ProcessosComboBox
              name={'processo'}
              dataForm={processosobsreportData}
              value={processosobsreportData.processo}
              setValue={addValorProcesso}
              label={'Processos'}
              />

              <InputInput
              type='text'
              maxLength={2048}
              id='observacao'
              label='Observacao'
              dataForm={processosobsreportData}
              className='inputIncNome'
              name='observacao'
              value={processosobsreportData.observacao}
              onChange={onChange}
              />


              <HistoricoComboBox
              name={'historico'}
              dataForm={processosobsreportData}
              value={processosobsreportData.historico}
              setValue={addValorHistorico}
              label={'Historico'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProcessosObsReport' data={processosobsreportData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosObsReportForm-${processosobsreportData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/processosobsreport'} id={processosobsreportData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };