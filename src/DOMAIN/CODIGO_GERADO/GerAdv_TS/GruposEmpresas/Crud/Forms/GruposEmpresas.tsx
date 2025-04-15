"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IGruposEmpresas } from '../../Interfaces/interface.GruposEmpresas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

interface GruposEmpresasFormProps {
    gruposempresasData: IGruposEmpresas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GruposEmpresasForm: React.FC<GruposEmpresasFormProps> = ({
    gruposempresasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOponentes, setNomeOponentes] = useState('');
            const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("oponentes") > 0) {
  oponentesApi
    .getById(getParamFromUrl("oponentes"))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresasData.id === 0) {
    gruposempresasData.oponente = getParamFromUrl("oponentes");
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

  if (gruposempresasData.id === 0) {
    gruposempresasData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorOponente = (e: any) => {
                        if (e?.id>0)
                        gruposempresasData.oponente = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        gruposempresasData.cliente = e.id;
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
  {nomeOponentes && (<h2>{nomeOponentes}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={gruposempresasData.descricao}
            onChange={onChange}
            required
          />

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={gruposempresasData.email}
onChange={onChange}               
/>

<Checkbox label="Inativo" name="inativo" checked={gruposempresasData.inativo} onChange={onChange} />
 
            <OponentesComboBox
            name={'oponente'}
            value={gruposempresasData.oponente}
            setValue={addValorOponente}
            label={'Oponentes'}
            />

<Input
type="text"
id="observacoes"
label="Observacoes"
className="inputIncNome"
name="observacoes"
value={gruposempresasData.observacoes}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={gruposempresasData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={gruposempresasData.icone}
onChange={onChange}               
/>

<Checkbox label="DespesaUnificada" name="despesaunificada" checked={gruposempresasData.despesaunificada} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gruposempresascli${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?gruposempresas=${gruposempresasData.id}`)}>Grupos Empresas Cli</div>

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
 