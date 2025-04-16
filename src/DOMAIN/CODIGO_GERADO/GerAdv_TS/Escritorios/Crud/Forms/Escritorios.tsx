"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IEscritorios } from '../../Interfaces/interface.Escritorios';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCep from '@/app/components/Inputs/InputCep'

interface EscritoriosFormProps {
    escritoriosData: IEscritorios;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EscritoriosForm: React.FC<EscritoriosFormProps> = ({
    escritoriosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  
    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={escritoriosData.nome}
            onChange={onChange}
            required
          />

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={escritoriosData.cnpj}
onChange={onChange}               
/>

<Checkbox label="Casa" name="casa" checked={escritoriosData.casa} onChange={onChange} />
<Checkbox label="Parceria" name="parceria" checked={escritoriosData.parceria} onChange={onChange} />
        
<Input
type="text"
id="oab"
label="OAB"
className="inputIncNome"
name="oab"
value={escritoriosData.oab}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={escritoriosData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={escritoriosData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={escritoriosData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={escritoriosData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={escritoriosData.fone}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={escritoriosData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={escritoriosData.site}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={escritoriosData.email}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={escritoriosData.obs}
onChange={onChange}               
/>

<Input
type="text"
id="advresponsavel"
label="AdvResponsavel"
className="inputIncNome"
name="advresponsavel"
value={escritoriosData.advresponsavel}
onChange={onChange}               
/>

<Input
type="text"
id="secretaria"
label="Secretaria"
className="inputIncNome"
name="secretaria"
value={escritoriosData.secretaria}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={escritoriosData.inscest}
onChange={onChange}               
/>

<Checkbox label="Correspondente" name="correspondente" checked={escritoriosData.correspondente} onChange={onChange} />
<Checkbox label="Top" name="top" checked={escritoriosData.top} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/advogados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?escritorios=${escritoriosData.id}`)}>Advogados</div>

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
 