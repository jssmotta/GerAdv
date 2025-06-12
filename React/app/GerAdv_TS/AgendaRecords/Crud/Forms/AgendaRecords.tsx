// Tracking: Forms.tsx.txt
'use client';
import { IAgendaRecords } from '@/app/GerAdv_TS/AgendaRecords/Interfaces/interface.AgendaRecords';
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
import { AgendaRecordsApi } from '../../Apis/ApiAgendaRecords';
import { useValidationsAgendaRecords } from '../../Hooks/hookAgendaRecords';
import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import ClientesSociosComboBox from '@/app/GerAdv_TS/ClientesSocios/ComboBox/ClientesSocios';
import ColaboradoresComboBox from '@/app/GerAdv_TS/Colaboradores/ComboBox/Colaboradores';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import { ClientesSociosApi } from '@/app/GerAdv_TS/ClientesSocios/Apis/ApiClientesSocios';
import { ColaboradoresApi } from '@/app/GerAdv_TS/Colaboradores/Apis/ApiColaboradores';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface AgendaRecordsFormProps {
  agendarecordsData: IAgendaRecords;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AgendaRecordsForm: React.FC<AgendaRecordsFormProps> = ({
  agendarecordsData, 
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
const dadoApi = new AgendaRecordsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgendaRecords();
const [nomeAgenda, setNomeAgenda] = useState('');
const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientesSocios, setNomeClientesSocios] = useState('');
const clientessociosApi = new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeColaboradores, setNomeColaboradores] = useState('');
const colaboradoresApi = new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('agenda') > 0) {
  if (agendarecordsData.id === 0 && agendarecordsData.agenda == 0) {
    agendaApi
    .getById(getParamFromUrl('agenda'))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    agendarecordsData.agenda = getParamFromUrl('agenda');
  }
}

if (getParamFromUrl('clientessocios') > 0) {
  if (agendarecordsData.id === 0 && agendarecordsData.clientessocios == 0) {
    clientessociosApi
    .getById(getParamFromUrl('clientessocios'))
    .then((response) => {
      setNomeClientesSocios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendarecordsData.clientessocios = getParamFromUrl('clientessocios');
  }
}

if (getParamFromUrl('colaboradores') > 0) {
  if (agendarecordsData.id === 0 && agendarecordsData.colaborador == 0) {
    colaboradoresApi
    .getById(getParamFromUrl('colaboradores'))
    .then((response) => {
      setNomeColaboradores(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendarecordsData.colaborador = getParamFromUrl('colaboradores');
  }
}

if (getParamFromUrl('foro') > 0) {
  if (agendarecordsData.id === 0 && agendarecordsData.foro == 0) {
    foroApi
    .getById(getParamFromUrl('foro'))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendarecordsData.foro = getParamFromUrl('foro');
  }
}
const addValorAgenda = (e: any) => {
  if (e?.id>0)
    agendarecordsData.agenda = e.id;
  };
  const addValorClientesSocios = (e: any) => {
    if (e?.id>0)
      agendarecordsData.clientessocios = e.id;
    };
    const addValorColaborador = (e: any) => {
      if (e?.id>0)
        agendarecordsData.colaborador = e.id;
      };
      const addValorForo = (e: any) => {
        if (e?.id>0)
          agendarecordsData.foro = e.id;
        };
        const onConfirm = (e: React.FormEvent) => {
          e.preventDefault();
          if (e.stopPropagation) e.stopPropagation();

            if (!isSubmitting) {
              setIsSubmitting(true);

              try {
                onSubmit(e);
              } catch (error) {
              console.error('Erro ao submeter formulário de AgendaRecords:', error);
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
                target: document.getElementById(`AgendaRecordsForm-${agendarecordsData.id}`)
              } as unknown as React.FormEvent;

              onSubmit(syntheticEvent);
            } catch (error) {
            console.error('Erro ao salvar AgendaRecords diretamente:', error);
            setIsSubmitting(false);
            if (onError) onError();
            }
          }
        };
        useEffect(() => {
          const el = document.querySelector('.nameFormMobile');
          if (el) {
            el.textContent = agendarecordsData?.id == 0 ? 'Editar AgendaRecords' : 'Adicionar Agenda Records';
          }
        }, [agendarecordsData.id]);
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

          <div className={isMobile ? 'form-container form-container-AgendaRecords' : 'form-container form-container-AgendaRecords'}>

            <form className='formInputCadInc' id={`AgendaRecordsForm-${agendarecordsData.id}`} onSubmit={onConfirm}>
              {!isMobile && (
                <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AgendaRecords' data={agendarecordsData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRecordsForm-${agendarecordsData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                )}
                <div className='grid-container'>


                  <AgendaComboBox
                  name={'agenda'}
                  dataForm={agendarecordsData}
                  value={agendarecordsData.agenda}
                  setValue={addValorAgenda}
                  label={'Agenda'}
                  />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='julgador'
                  label='Julgador'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='julgador'
                  value={agendarecordsData.julgador}
                  onChange={onChange}
                  />


                  <ClientesSociosComboBox
                  name={'clientessocios'}
                  dataForm={agendarecordsData}
                  value={agendarecordsData.clientessocios}
                  setValue={addValorClientesSocios}
                  label={'Clientes Socios'}
                  />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='perito'
                  label='Perito'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='perito'
                  value={agendarecordsData.perito}
                  onChange={onChange}
                  />


                  <ColaboradoresComboBox
                  name={'colaborador'}
                  dataForm={agendarecordsData}
                  value={agendarecordsData.colaborador}
                  setValue={addValorColaborador}
                  label={'Colaborador'}
                  />

                  <ForoComboBox
                  name={'foro'}
                  dataForm={agendarecordsData}
                  value={agendarecordsData.foro}
                  setValue={addValorForo}
                  label={'Foro'}
                  />
                  <InputCheckbox dataForm={agendarecordsData} label='Aviso1' name='aviso1' checked={agendarecordsData.aviso1} onChange={onChange} />
                  <InputCheckbox dataForm={agendarecordsData} label='Aviso2' name='aviso2' checked={agendarecordsData.aviso2} onChange={onChange} />
                  <InputCheckbox dataForm={agendarecordsData} label='Aviso3' name='aviso3' checked={agendarecordsData.aviso3} onChange={onChange} />
                </div><div className='grid-container'>
                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='crmaviso1'
                  label='CrmAviso1'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='crmaviso1'
                  value={agendarecordsData.crmaviso1}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='crmaviso2'
                  label='CrmAviso2'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='crmaviso2'
                  value={agendarecordsData.crmaviso2}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='crmaviso3'
                  label='CrmAviso3'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='crmaviso3'
                  value={agendarecordsData.crmaviso3}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='dataaviso1'
                  label='DataAviso1'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='dataaviso1'
                  value={agendarecordsData.dataaviso1}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='dataaviso2'
                  label='DataAviso2'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='dataaviso2'
                  value={agendarecordsData.dataaviso2}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='dataaviso3'
                  label='DataAviso3'
                  dataForm={agendarecordsData}
                  className='inputIncNome'
                  name='dataaviso3'
                  value={agendarecordsData.dataaviso3}
                  onChange={onChange}
                  />

                </div>
              </form>


              {isMobile && (
                <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AgendaRecords' data={agendarecordsData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRecordsForm-${agendarecordsData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                )}
                <DeleteButton page={'/pages/agendarecords'} id={agendarecordsData.id} closeModel={onClose} dadoApi={dadoApi} />
              </div>
              <div className='form-spacer'></div>
              </>
            );
          };