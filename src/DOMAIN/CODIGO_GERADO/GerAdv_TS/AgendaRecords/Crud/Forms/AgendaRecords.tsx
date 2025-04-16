"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAgendaRecords } from '../../Interfaces/interface.AgendaRecords';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import ClientesSociosComboBox from '@/app/GerAdv_TS/ClientesSocios/ComboBox/ClientesSocios';
import ColaboradoresComboBox from '@/app/GerAdv_TS/Colaboradores/ComboBox/Colaboradores';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import { ClientesSociosApi } from '@/app/GerAdv_TS/ClientesSocios/Apis/ApiClientesSocios';
import { ColaboradoresApi } from '@/app/GerAdv_TS/Colaboradores/Apis/ApiColaboradores';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';

interface AgendaRecordsFormProps {
    agendarecordsData: IAgendaRecords;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaRecordsForm: React.FC<AgendaRecordsFormProps> = ({
    agendarecordsData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAgenda, setNomeAgenda] = useState('');
            const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientesSocios, setNomeClientesSocios] = useState('');
            const clientessociosApi = new ClientesSociosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeColaboradores, setNomeColaboradores] = useState('');
            const colaboradoresApi = new ColaboradoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
            const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("agenda") > 0) {
  agendaApi
    .getById(getParamFromUrl("agenda"))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendarecordsData.id === 0) {
    agendarecordsData.agenda = getParamFromUrl("agenda");
  }
}
 
if (getParamFromUrl("clientessocios") > 0) {
  clientessociosApi
    .getById(getParamFromUrl("clientessocios"))
    .then((response) => {
      setNomeClientesSocios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendarecordsData.id === 0) {
    agendarecordsData.clientessocios = getParamFromUrl("clientessocios");
  }
}
 
if (getParamFromUrl("colaboradores") > 0) {
  colaboradoresApi
    .getById(getParamFromUrl("colaboradores"))
    .then((response) => {
      setNomeColaboradores(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendarecordsData.id === 0) {
    agendarecordsData.colaborador = getParamFromUrl("colaboradores");
  }
}
 
if (getParamFromUrl("foro") > 0) {
  foroApi
    .getById(getParamFromUrl("foro"))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendarecordsData.id === 0) {
    agendarecordsData.foro = getParamFromUrl("foro");
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
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeAgenda && (<h2>{nomeAgenda}</h2>)}
{nomeClientesSocios && (<h2>{nomeClientesSocios}</h2>)}
{nomeColaboradores && (<h2>{nomeColaboradores}</h2>)}
{nomeForo && (<h2>{nomeForo}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <AgendaComboBox
            name={'agenda'}
            value={agendarecordsData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

<Input
type="text"
id="julgador"
label="Julgador"
className="inputIncNome"
name="julgador"
value={agendarecordsData.julgador}
onChange={onChange}               
/>

            <ClientesSociosComboBox
            name={'clientessocios'}
            value={agendarecordsData.clientessocios}
            setValue={addValorClientesSocios}
            label={'Clientes Socios'}
            />

<Input
type="text"
id="perito"
label="Perito"
className="inputIncNome"
name="perito"
value={agendarecordsData.perito}
onChange={onChange}               
/>

            <ColaboradoresComboBox
            name={'colaborador'}
            value={agendarecordsData.colaborador}
            setValue={addValorColaborador}
            label={'Colaboradores'}
            />

            <ForoComboBox
            name={'foro'}
            value={agendarecordsData.foro}
            setValue={addValorForo}
            label={'Foro'}
            />

<Checkbox label="Aviso1" name="aviso1" checked={agendarecordsData.aviso1} onChange={onChange} />
<Checkbox label="Aviso2" name="aviso2" checked={agendarecordsData.aviso2} onChange={onChange} />
<Checkbox label="Aviso3" name="aviso3" checked={agendarecordsData.aviso3} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="text"
id="crmaviso1"
label="CrmAviso1"
className="inputIncNome"
name="crmaviso1"
value={agendarecordsData.crmaviso1}
onChange={onChange}               
/>

<Input
type="text"
id="crmaviso2"
label="CrmAviso2"
className="inputIncNome"
name="crmaviso2"
value={agendarecordsData.crmaviso2}
onChange={onChange}               
/>

<Input
type="text"
id="crmaviso3"
label="CrmAviso3"
className="inputIncNome"
name="crmaviso3"
value={agendarecordsData.crmaviso3}
onChange={onChange}               
/>

<Input
type="text"
id="dataaviso1"
label="DataAviso1"
className="inputIncNome"
name="dataaviso1"
value={agendarecordsData.dataaviso1}
onChange={onChange}               
/>

<Input
type="text"
id="dataaviso2"
label="DataAviso2"
className="inputIncNome"
name="dataaviso2"
value={agendarecordsData.dataaviso2}
onChange={onChange}               
/>

<Input
type="text"
id="dataaviso3"
label="DataAviso3"
className="inputIncNome"
name="dataaviso3"
value={agendarecordsData.dataaviso3}
onChange={onChange}               
/>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 