"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IContatoCRM } from '../../Interfaces/interface.ContatoCRM';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import TipoContatoCRMComboBox from '@/app/GerAdv_TS/TipoContatoCRM/ComboBox/TipoContatoCRM';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { TipoContatoCRMApi } from '@/app/GerAdv_TS/TipoContatoCRM/Apis/ApiTipoContatoCRM';

interface ContatoCRMFormProps {
    contatocrmData: IContatoCRM;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContatoCRMForm: React.FC<ContatoCRMFormProps> = ({
    contatocrmData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoContatoCRM, setNomeTipoContatoCRM] = useState('');
            const tipocontatocrmApi = new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmData.id === 0) {
    contatocrmData.operador = getParamFromUrl("operador");
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

  if (contatocrmData.id === 0) {
    contatocrmData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmData.id === 0) {
    contatocrmData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("tipocontatocrm") > 0) {
  tipocontatocrmApi
    .getById(getParamFromUrl("tipocontatocrm"))
    .then((response) => {
      setNomeTipoContatoCRM(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmData.id === 0) {
    contatocrmData.tipocontatocrm = getParamFromUrl("tipocontatocrm");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.operador = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.cliente = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.processo = e.id;
                      };
 const addValorTipoContatoCRM = (e: any) => {
                        if (e?.id>0)
                        contatocrmData.tipocontatocrm = e.id;
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
  {nomeOperador && (<h2>{nomeOperador}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}
{nomeTipoContatoCRM && (<h2>{nomeTipoContatoCRM}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="ageclienteavisado"
label="AgeClienteAvisado"
className="inputIncNome"
name="ageclienteavisado"
value={contatocrmData.ageclienteavisado}
onChange={onChange}               
/>

<Input
type="text"
id="docsviarecebimento"
label="DocsViaRecebimento"
className="inputIncNome"
name="docsviarecebimento"
value={contatocrmData.docsviarecebimento}
onChange={onChange}               
/>

<Checkbox label="NaoPublicavel" name="naopublicavel" checked={contatocrmData.naopublicavel} onChange={onChange} />
<Checkbox label="Notificar" name="notificar" checked={contatocrmData.notificar} onChange={onChange} />
<Checkbox label="Ocultar" name="ocultar" checked={contatocrmData.ocultar} onChange={onChange} />
        
<Input
type="text"
id="assunto"
label="Assunto"
className="inputIncNome"
name="assunto"
value={contatocrmData.assunto}
onChange={onChange}               
/>

<Checkbox label="IsDocsRecebidos" name="isdocsrecebidos" checked={contatocrmData.isdocsrecebidos} onChange={onChange} />
        
<Input
type="text"
id="quemnotificou"
label="QuemNotificou"
className="inputIncNome"
name="quemnotificou"
value={contatocrmData.quemnotificou}
onChange={onChange}               
/>

<Input
type="text"
id="datanotificou"
label="DataNotificou"
className="inputIncNome"
name="datanotificou"
value={contatocrmData.datanotificou}
onChange={onChange}               
/>

</div><div className="grid-container"> 
            <OperadorComboBox
            name={'operador'}
            value={contatocrmData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={contatocrmData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="horanotificou"
label="HoraNotificou"
className="inputIncNome"
name="horanotificou"
value={contatocrmData.horanotificou}
onChange={onChange}               
/>

<Input
type="text"
id="objetonotificou"
label="ObjetoNotificou"
className="inputIncNome"
name="objetonotificou"
value={contatocrmData.objetonotificou}
onChange={onChange}               
/>

<Input
type="text"
id="pessoacontato"
label="PessoaContato"
className="inputIncNome"
name="pessoacontato"
value={contatocrmData.pessoacontato}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={contatocrmData.data}
onChange={onChange}               
/>

<Input
type="text"
id="tempo"
label="Tempo"
className="inputIncNome"
name="tempo"
value={contatocrmData.tempo}
onChange={onChange}               
/>

<Input
type="text"
id="horainicial"
label="HoraInicial"
className="inputIncNome"
name="horainicial"
value={contatocrmData.horainicial}
onChange={onChange}               
/>

<Input
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={contatocrmData.horafinal}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={contatocrmData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

</div><div className="grid-container"><Checkbox label="Importante" name="importante" checked={contatocrmData.importante} onChange={onChange} />
<Checkbox label="Urgente" name="urgente" checked={contatocrmData.urgente} onChange={onChange} />
<Checkbox label="GerarHoraTrabalhada" name="gerarhoratrabalhada" checked={contatocrmData.gerarhoratrabalhada} onChange={onChange} />
<Checkbox label="ExibirNoTopo" name="exibirnotopo" checked={contatocrmData.exibirnotopo} onChange={onChange} />
 
            <TipoContatoCRMComboBox
            name={'tipocontatocrm'}
            value={contatocrmData.tipocontatocrm}
            setValue={addValorTipoContatoCRM}
            label={'Tipo Contato C R M'}
            />

<Input
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={contatocrmData.contato}
onChange={onChange}               
/>

<Input
type="text"
id="emocao"
label="Emocao"
className="inputIncNome"
name="emocao"
value={contatocrmData.emocao}
onChange={onChange}               
/>

<Checkbox label="Continuar" name="continuar" checked={contatocrmData.continuar} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contatocrmoperador${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?contatocrm=${contatocrmData.id}`)}>Contato C R M Operador</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/docsrecebidositens${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?contatocrm=${contatocrmData.id}`)}>Docs Recebidos Itens</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/recados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?contatocrm=${contatocrmData.id}`)}>Recados</div>

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
 