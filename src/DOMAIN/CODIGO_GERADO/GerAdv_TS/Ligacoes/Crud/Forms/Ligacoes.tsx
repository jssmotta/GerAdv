"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ILigacoes } from '../../Interfaces/interface.Ligacoes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import RamalComboBox from '@/app/GerAdv_TS/Ramal/ComboBox/Ramal';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { RamalApi } from '@/app/GerAdv_TS/Ramal/Apis/ApiRamal';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface LigacoesFormProps {
    ligacoesData: ILigacoes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const LigacoesForm: React.FC<LigacoesFormProps> = ({
    ligacoesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeRamal, setNomeRamal] = useState('');
            const ramalApi = new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (ligacoesData.id === 0) {
    ligacoesData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("ramal") > 0) {
  ramalApi
    .getById(getParamFromUrl("ramal"))
    .then((response) => {
      setNomeRamal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (ligacoesData.id === 0) {
    ligacoesData.ramal = getParamFromUrl("ramal");
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

  if (ligacoesData.id === 0) {
    ligacoesData.processo = getParamFromUrl("processos");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        ligacoesData.cliente = e.id;
                      };
 const addValorRamal = (e: any) => {
                        if (e?.id>0)
                        ligacoesData.ramal = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        ligacoesData.processo = e.id;
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
  {nomeClientes && (<h2>{nomeClientes}</h2>)}
{nomeRamal && (<h2>{nomeRamal}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={ligacoesData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="assunto"
label="Assunto"
className="inputIncNome"
name="assunto"
value={ligacoesData.assunto}
onChange={onChange}               
/>

<Input
type="text"
id="ageclienteavisado"
label="AgeClienteAvisado"
className="inputIncNome"
name="ageclienteavisado"
value={ligacoesData.ageclienteavisado}
onChange={onChange}               
/>

<Checkbox label="Celular" name="celular" checked={ligacoesData.celular} onChange={onChange} />
 
            <ClientesComboBox
            name={'cliente'}
            value={ligacoesData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={ligacoesData.contato}
onChange={onChange}               
/>

<Input
type="text"
id="datarealizada"
label="DataRealizada"
className="inputIncNome"
name="datarealizada"
value={ligacoesData.datarealizada}
onChange={onChange}               
/>

<Input
type="text"
id="quemid"
label="QuemID"
className="inputIncNome"
name="quemid"
value={ligacoesData.quemid}
onChange={onChange}               
/>

<Input
type="text"
id="telefonista"
label="Telefonista"
className="inputIncNome"
name="telefonista"
value={ligacoesData.telefonista}
onChange={onChange}               
/>

<Input
type="text"
id="ultimoaviso"
label="UltimoAviso"
className="inputIncNome"
name="ultimoaviso"
value={ligacoesData.ultimoaviso}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={ligacoesData.horafinal}
onChange={onChange}               
/>

<Input
type="text"
id="quemcodigo"
label="QuemCodigo"
className="inputIncNome"
name="quemcodigo"
value={ligacoesData.quemcodigo}
onChange={onChange}               
/>

<Input
type="text"
id="solicitante"
label="Solicitante"
className="inputIncNome"
name="solicitante"
value={ligacoesData.solicitante}
onChange={onChange}               
/>

<Input
type="text"
id="para"
label="Para"
className="inputIncNome"
name="para"
value={ligacoesData.para}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={ligacoesData.fone}
onChange={onChange}               
/>

            <RamalComboBox
            name={'ramal'}
            value={ligacoesData.ramal}
            setValue={addValorRamal}
            label={'Ramal'}
            />

<Checkbox label="Particular" name="particular" checked={ligacoesData.particular} onChange={onChange} />
<Checkbox label="Realizada" name="realizada" checked={ligacoesData.realizada} onChange={onChange} />
        
<Input
type="text"
id="status"
label="Status"
className="inputIncNome"
name="status"
value={ligacoesData.status}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={ligacoesData.data}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={ligacoesData.hora}
onChange={onChange}               
/>

<Checkbox label="Urgente" name="urgente" checked={ligacoesData.urgente} onChange={onChange} />
        
<Input
type="text"
id="ligarpara"
label="LigarPara"
className="inputIncNome"
name="ligarpara"
value={ligacoesData.ligarpara}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={ligacoesData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Checkbox label="StartScreen" name="startscreen" checked={ligacoesData.startscreen} onChange={onChange} />
        
<Input
type="text"
id="emotion"
label="Emotion"
className="inputIncNome"
name="emotion"
value={ligacoesData.emotion}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/recados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?ligacoes=${ligacoesData.id}`)}>Recados</div>

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
 