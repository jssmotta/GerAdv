﻿"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IRecados } from '../../Interfaces/interface.Recados';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import HistoricoComboBox from '@/app/GerAdv_TS/Historico/ComboBox/Historico';
import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import LigacoesComboBox from '@/app/GerAdv_TS/Ligacoes/ComboBox/Ligacoes';
import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { HistoricoApi } from '@/app/GerAdv_TS/Historico/Apis/ApiHistorico';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';
import { LigacoesApi } from '@/app/GerAdv_TS/Ligacoes/Apis/ApiLigacoes';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';

interface RecadosFormProps {
    recadosData: IRecados;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const RecadosForm: React.FC<RecadosFormProps> = ({
    recadosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeHistorico, setNomeHistorico] = useState('');
            const historicoApi = new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeContatoCRM, setNomeContatoCRM] = useState('');
            const contatocrmApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeLigacoes, setNomeLigacoes] = useState('');
            const ligacoesApi = new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAgenda, setNomeAgenda] = useState('');
            const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (recadosData.id === 0) {
    recadosData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (recadosData.id === 0) {
    recadosData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("historico") > 0) {
  historicoApi
    .getById(getParamFromUrl("historico"))
    .then((response) => {
      setNomeHistorico(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (recadosData.id === 0) {
    recadosData.historico = getParamFromUrl("historico");
  }
}
 
if (getParamFromUrl("contatocrm") > 0) {
  contatocrmApi
    .getById(getParamFromUrl("contatocrm"))
    .then((response) => {
      setNomeContatoCRM(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (recadosData.id === 0) {
    recadosData.contatocrm = getParamFromUrl("contatocrm");
  }
}
 
if (getParamFromUrl("ligacoes") > 0) {
  ligacoesApi
    .getById(getParamFromUrl("ligacoes"))
    .then((response) => {
      setNomeLigacoes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (recadosData.id === 0) {
    recadosData.ligacoes = getParamFromUrl("ligacoes");
  }
}
 
if (getParamFromUrl("agenda") > 0) {
  agendaApi
    .getById(getParamFromUrl("agenda"))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (recadosData.id === 0) {
    recadosData.agenda = getParamFromUrl("agenda");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        recadosData.processo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        recadosData.cliente = e.id;
                      };
 const addValorHistorico = (e: any) => {
                        if (e?.id>0)
                        recadosData.historico = e.id;
                      };
 const addValorContatoCRM = (e: any) => {
                        if (e?.id>0)
                        recadosData.contatocrm = e.id;
                      };
 const addValorLigacoes = (e: any) => {
                        if (e?.id>0)
                        recadosData.ligacoes = e.id;
                      };
 const addValorAgenda = (e: any) => {
                        if (e?.id>0)
                        recadosData.agenda = e.id;
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
  {nomeProcessos && (<h2>{nomeProcessos}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}
{nomeHistorico && (<h2>{nomeHistorico}</h2>)}
{nomeContatoCRM && (<h2>{nomeContatoCRM}</h2>)}
{nomeLigacoes && (<h2>{nomeLigacoes}</h2>)}
{nomeAgenda && (<h2>{nomeAgenda}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="clientenome"
label="ClienteNome"
className="inputIncNome"
name="clientenome"
value={recadosData.clientenome}
onChange={onChange}               
/>

<Input
type="text"
id="de"
label="De"
className="inputIncNome"
name="de"
value={recadosData.de}
onChange={onChange}               
/>

<Input
type="text"
id="para"
label="Para"
className="inputIncNome"
name="para"
value={recadosData.para}
onChange={onChange}               
/>

<Input
type="text"
id="assunto"
label="Assunto"
className="inputIncNome"
name="assunto"
value={recadosData.assunto}
onChange={onChange}               
/>

<Checkbox label="Concluido" name="concluido" checked={recadosData.concluido} onChange={onChange} />
 
            <ProcessosComboBox
            name={'processo'}
            value={recadosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={recadosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="recado"
label="Recado"
className="inputIncNome"
name="recado"
value={recadosData.recado}
onChange={onChange}               
/>

<Checkbox label="Urgente" name="urgente" checked={recadosData.urgente} onChange={onChange} />
</div><div className="grid-container"><Checkbox label="Importante" name="importante" checked={recadosData.importante} onChange={onChange} />
        
<Input
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={recadosData.hora}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={recadosData.data}
onChange={onChange}               
/>

<Checkbox label="Voltara" name="voltara" checked={recadosData.voltara} onChange={onChange} />
<Checkbox label="Pessoal" name="pessoal" checked={recadosData.pessoal} onChange={onChange} />
<Checkbox label="Retornar" name="retornar" checked={recadosData.retornar} onChange={onChange} />
        
<Input
type="text"
id="retornodata"
label="RetornoData"
className="inputIncNome"
name="retornodata"
value={recadosData.retornodata}
onChange={onChange}               
/>

<Input
type="text"
id="emotion"
label="Emotion"
className="inputIncNome"
name="emotion"
value={recadosData.emotion}
onChange={onChange}               
/>

<Input
type="text"
id="internetid"
label="InternetID"
className="inputIncNome"
name="internetid"
value={recadosData.internetid}
onChange={onChange}               
/>

<Checkbox label="Uploaded" name="uploaded" checked={recadosData.uploaded} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="text"
id="natureza"
label="Natureza"
className="inputIncNome"
name="natureza"
value={recadosData.natureza}
onChange={onChange}               
/>

<Checkbox label="BIU" name="biu" checked={recadosData.biu} onChange={onChange} />
<Checkbox label="AguardarRetorno" name="aguardarretorno" checked={recadosData.aguardarretorno} onChange={onChange} />
        
<Input
type="text"
id="aguardarretornopara"
label="AguardarRetornoPara"
className="inputIncNome"
name="aguardarretornopara"
value={recadosData.aguardarretornopara}
onChange={onChange}               
/>

<Checkbox label="AguardarRetornoOK" name="aguardarretornook" checked={recadosData.aguardarretornook} onChange={onChange} />
        
<Input
type="text"
id="paraid"
label="ParaID"
className="inputIncNome"
name="paraid"
value={recadosData.paraid}
onChange={onChange}               
/>

<Checkbox label="NaoPublicavel" name="naopublicavel" checked={recadosData.naopublicavel} onChange={onChange} />
<Checkbox label="IsContatoCRM" name="iscontatocrm" checked={recadosData.iscontatocrm} onChange={onChange} />
        
<Input
type="text"
id="masterid"
label="MasterID"
className="inputIncNome"
name="masterid"
value={recadosData.masterid}
onChange={onChange}               
/>

<Input
type="text"
id="listapara"
label="ListaPara"
className="inputIncNome"
name="listapara"
value={recadosData.listapara}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="Typed" name="typed" checked={recadosData.typed} onChange={onChange} />
        
<Input
type="text"
id="assuntorecado"
label="AssuntoRecado"
className="inputIncNome"
name="assuntorecado"
value={recadosData.assuntorecado}
onChange={onChange}               
/>

            <HistoricoComboBox
            name={'historico'}
            value={recadosData.historico}
            setValue={addValorHistorico}
            label={'Historico'}
            />

            <ContatoCRMComboBox
            name={'contatocrm'}
            value={recadosData.contatocrm}
            setValue={addValorContatoCRM}
            label={'Contato C R M'}
            />

            <LigacoesComboBox
            name={'ligacoes'}
            value={recadosData.ligacoes}
            setValue={addValorLigacoes}
            label={'Ligacoes'}
            />

            <AgendaComboBox
            name={'agenda'}
            value={recadosData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/alarmsms${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?recados=${recadosData.id}`)}>Alarm S M S</div>

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
 