// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IClientesSocios } from '@/app/GerAdv_TS/ClientesSocios/Interfaces/interface.ClientesSocios';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCnpj from '@/app/components/Inputs/InputCnpj'

interface ClientesSociosFormProps {
    clientessociosData: IClientesSocios;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ClientesSociosForm: React.FC<ClientesSociosFormProps> = ({
    clientessociosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (clientessociosData.id === 0) {
    clientessociosData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        clientessociosData.cliente = e.id;
                      };

    const onConfirm = (e: React.FormEvent) => {
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de ClientesSocios:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`ClientesSociosForm-${clientessociosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ClientesSocios diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ClientesSocios' : 'form-container form-container-ClientesSocios'}>
       
            <form className='formInputCadInc' id={`ClientesSociosForm-${clientessociosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={clientessociosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ClientesSociosForm-${clientessociosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={clientessociosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

                <InputCheckbox label="SomenteRepresentante" name="somenterepresentante" checked={clientessociosData.somenterepresentante} onChange={onChange} />
        
<InputInput
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={clientessociosData.idade}
onChange={onChange}               
/>

<InputCheckbox label="IsRepresentanteLegal" name="isrepresentantelegal" checked={clientessociosData.isrepresentantelegal} onChange={onChange} />
        
<InputInput
type="text"
id="qualificacao"
label="Qualificacao"
className="inputIncNome"
name="qualificacao"
value={clientessociosData.qualificacao}
onChange={onChange}               
/>

<InputCheckbox label="Sexo" name="sexo" checked={clientessociosData.sexo} onChange={onChange} />
        
<InputInput
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={clientessociosData.dtnasc}
onChange={onChange}               
/>

<InputInput
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={clientessociosData.site}
onChange={onChange}               
/>

<InputInput
type="text"
id="representantelegal"
label="RepresentanteLegal"
className="inputIncNome"
name="representantelegal"
value={clientessociosData.representantelegal}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={clientessociosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

</div><div className="grid-container">        
<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={clientessociosData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={clientessociosData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={clientessociosData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={clientessociosData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={clientessociosData.rg}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={clientessociosData.cpf}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={clientessociosData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="participacao"
label="Participacao"
className="inputIncNome"
name="participacao"
value={clientessociosData.participacao}
onChange={onChange}               
/>

<InputInput
type="text"
id="cargo"
label="Cargo"
className="inputIncNome"
name="cargo"
value={clientessociosData.cargo}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={clientessociosData.email}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="obs"
label="Obs"
className="inputIncNome"
name="obs"
value={clientessociosData.obs}
onChange={onChange}               
/>

<InputInput
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={clientessociosData.cnh}
onChange={onChange}               
/>

<InputInput
type="text"
id="datacontrato"
label="DataContrato"
className="inputIncNome"
name="datacontrato"
value={clientessociosData.datacontrato}
onChange={onChange}               
/>

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={clientessociosData.cnpj}
onChange={onChange}               
/>

<InputInput
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={clientessociosData.inscest}
onChange={onChange}               
/>

<InputInput
type="text"
id="socioempresaadminnome"
label="SocioEmpresaAdminNome"
className="inputIncNome"
name="socioempresaadminnome"
value={clientessociosData.socioempresaadminnome}
onChange={onChange}               
/>

<InputInput
type="text"
id="enderecosocio"
label="EnderecoSocio"
className="inputIncNome"
name="enderecosocio"
value={clientessociosData.enderecosocio}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairrosocio"
label="BairroSocio"
className="inputIncNome"
name="bairrosocio"
value={clientessociosData.bairrosocio}
onChange={onChange}               
/>

<InputInput
type="text"
id="cepsocio"
label="CEPSocio"
className="inputIncNome"
name="cepsocio"
value={clientessociosData.cepsocio}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidadesocio"
label="CidadeSocio"
className="inputIncNome"
name="cidadesocio"
value={clientessociosData.cidadesocio}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="rgdataexp"
label="RGDataExp"
className="inputIncNome"
name="rgdataexp"
value={clientessociosData.rgdataexp}
onChange={onChange}               
/>

<InputCheckbox label="SocioEmpresaAdminSomente" name="socioempresaadminsomente" checked={clientessociosData.socioempresaadminsomente} onChange={onChange} />
<InputCheckbox label="Tipo" name="tipo" checked={clientessociosData.tipo} onChange={onChange} />
        
<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={clientessociosData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={clientessociosData.class}
onChange={onChange}               
/>

<InputCheckbox label="Ani" name="ani" checked={clientessociosData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 