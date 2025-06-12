// Tracking: Forms.tsx.txt
'use client';
import { IHistorico } from '@/app/GerAdv_TS/Historico/Interfaces/interface.Historico';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { HistoricoApi } from '../../Apis/ApiHistorico';
import { useValidationsHistorico } from '../../Hooks/hookHistorico';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import PrecatoriaComboBox from '@/app/GerAdv_TS/Precatoria/ComboBox/Precatoria';
import ApensoComboBox from '@/app/GerAdv_TS/Apenso/ComboBox/Apenso';
import FaseComboBox from '@/app/GerAdv_TS/Fase/ComboBox/Fase';
import StatusAndamentoComboBox from '@/app/GerAdv_TS/StatusAndamento/ComboBox/StatusAndamento';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { PrecatoriaApi } from '@/app/GerAdv_TS/Precatoria/Apis/ApiPrecatoria';
import { ApensoApi } from '@/app/GerAdv_TS/Apenso/Apis/ApiApenso';
import { FaseApi } from '@/app/GerAdv_TS/Fase/Apis/ApiFase';
import { StatusAndamentoApi } from '@/app/GerAdv_TS/StatusAndamento/Apis/ApiStatusAndamento';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface HistoricoFormProps {
  historicoData: IHistorico;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const HistoricoForm: React.FC<HistoricoFormProps> = ({
  historicoData, 
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
const dadoApi = new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsHistorico();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrecatoria, setNomePrecatoria] = useState('');
const precatoriaApi = new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeApenso, setNomeApenso] = useState('');
const apensoApi = new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFase, setNomeFase] = useState('');
const faseApi = new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeStatusAndamento, setNomeStatusAndamento] = useState('');
const statusandamentoApi = new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (historicoData.id === 0 && historicoData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    historicoData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('precatoria') > 0) {
  if (historicoData.id === 0 && historicoData.precatoria == 0) {
    precatoriaApi
    .getById(getParamFromUrl('precatoria'))
    .then((response) => {
      setNomePrecatoria(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    historicoData.precatoria = getParamFromUrl('precatoria');
  }
}

if (getParamFromUrl('apenso') > 0) {
  if (historicoData.id === 0 && historicoData.apenso == 0) {
    apensoApi
    .getById(getParamFromUrl('apenso'))
    .then((response) => {
      setNomeApenso(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    historicoData.apenso = getParamFromUrl('apenso');
  }
}

if (getParamFromUrl('fase') > 0) {
  if (historicoData.id === 0 && historicoData.fase == 0) {
    faseApi
    .getById(getParamFromUrl('fase'))
    .then((response) => {
      setNomeFase(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    historicoData.fase = getParamFromUrl('fase');
  }
}

if (getParamFromUrl('statusandamento') > 0) {
  if (historicoData.id === 0 && historicoData.statusandamento == 0) {
    statusandamentoApi
    .getById(getParamFromUrl('statusandamento'))
    .then((response) => {
      setNomeStatusAndamento(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    historicoData.statusandamento = getParamFromUrl('statusandamento');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    historicoData.processo = e.id;
  };
  const addValorPrecatoria = (e: any) => {
    if (e?.id>0)
      historicoData.precatoria = e.id;
    };
    const addValorApenso = (e: any) => {
      if (e?.id>0)
        historicoData.apenso = e.id;
      };
      const addValorFase = (e: any) => {
        if (e?.id>0)
          historicoData.fase = e.id;
        };
        const addValorStatusAndamento = (e: any) => {
          if (e?.id>0)
            historicoData.statusandamento = e.id;
          };
          const onConfirm = (e: React.FormEvent) => {
            e.preventDefault();
            if (e.stopPropagation) e.stopPropagation();

              if (!isSubmitting) {
                setIsSubmitting(true);

                try {
                  onSubmit(e);
                } catch (error) {
                console.error('Erro ao submeter formulário de Historico:', error);
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
                  target: document.getElementById(`HistoricoForm-${historicoData.id}`)
                } as unknown as React.FormEvent;

                onSubmit(syntheticEvent);
              } catch (error) {
              console.error('Erro ao salvar Historico diretamente:', error);
              setIsSubmitting(false);
              if (onError) onError();
              }
            }
          };
          useEffect(() => {
            const el = document.querySelector('.nameFormMobile');
            if (el) {
              el.textContent = historicoData?.id == 0 ? 'Editar Historico' : 'Adicionar Historico';
            }
          }, [historicoData.id]);
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

            <div className={isMobile ? 'form-container form-container-Historico' : 'form-container form-container-Historico'}>

              <form className='formInputCadInc' id={`HistoricoForm-${historicoData.id}`} onSubmit={onConfirm}>
                {!isMobile && (
                  <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Historico' data={historicoData} isSubmitting={isSubmitting} onClose={onClose} formId={`HistoricoForm-${historicoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                  )}
                  <div className='grid-container'>


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='extraid'
                    label='ExtraID'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='extraid'
                    value={historicoData.extraid}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='idne'
                    label='IDNE'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='idne'
                    value={historicoData.idne}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='liminarorigem'
                    label='LiminarOrigem'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='liminarorigem'
                    value={historicoData.liminarorigem}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={historicoData} label='NaoPublicavel' name='naopublicavel' checked={historicoData.naopublicavel} onChange={onChange} />

                    <ProcessosComboBox
                    name={'processo'}
                    dataForm={historicoData}
                    value={historicoData.processo}
                    setValue={addValorProcesso}
                    label={'Processos'}
                    />

                    <PrecatoriaComboBox
                    name={'precatoria'}
                    dataForm={historicoData}
                    value={historicoData.precatoria}
                    setValue={addValorPrecatoria}
                    label={'Precatoria'}
                    />

                    <ApensoComboBox
                    name={'apenso'}
                    dataForm={historicoData}
                    value={historicoData.apenso}
                    setValue={addValorApenso}
                    label={'Apenso'}
                    />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='idinstprocesso'
                    label='IDInstProcesso'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='idinstprocesso'
                    value={historicoData.idinstprocesso}
                    onChange={onChange}
                    />


                    <FaseComboBox
                    name={'fase'}
                    dataForm={historicoData}
                    value={historicoData.fase}
                    setValue={addValorFase}
                    label={'Fase'}
                    />
                  </div><div className='grid-container'>
                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='data'
                    label='Data'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='data'
                    value={historicoData.data}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2147483647}
                    id='observacao'
                    label='Observacao'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='observacao'
                    value={historicoData.observacao}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={historicoData} label='Agendado' name='agendado' checked={historicoData.agendado} onChange={onChange} />
                    <InputCheckbox dataForm={historicoData} label='Concluido' name='concluido' checked={historicoData.concluido} onChange={onChange} />
                    <InputCheckbox dataForm={historicoData} label='MesmaAgenda' name='mesmaagenda' checked={historicoData.mesmaagenda} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='sad'
                    label='SAD'
                    dataForm={historicoData}
                    className='inputIncNome'
                    name='sad'
                    value={historicoData.sad}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={historicoData} label='Resumido' name='resumido' checked={historicoData.resumido} onChange={onChange} />

                    <StatusAndamentoComboBox
                    name={'statusandamento'}
                    dataForm={historicoData}
                    value={historicoData.statusandamento}
                    setValue={addValorStatusAndamento}
                    label={'Status Andamento'}
                    />
                    <InputCheckbox dataForm={historicoData} label='Top' name='top' checked={historicoData.top} onChange={onChange} />
                  </div>
                </form>


                {isMobile && (
                  <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Historico' data={historicoData} isSubmitting={isSubmitting} onClose={onClose} formId={`HistoricoForm-${historicoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                  )}
                  <DeleteButton page={'/pages/historico'} id={historicoData.id} closeModel={onClose} dadoApi={dadoApi} />
                </div>
                <div className='form-spacer'></div>
                </>
              );
            };