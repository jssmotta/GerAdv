"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IForo } from '../../Interfaces/interface.Foro';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import InputCep from '@/app/components/Inputs/InputCep'

interface ForoFormProps {
    foroData: IForo;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ForoForm: React.FC<ForoFormProps> = ({
    foroData,
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
            value={foroData.nome}
            onChange={onChange}
            required
          />

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={foroData.email}
onChange={onChange}               
/>

<Checkbox label="Unico" name="unico" checked={foroData.unico} onChange={onChange} />
        
<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={foroData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={foroData.site}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={foroData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={foroData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={foroData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={foroData.fax}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={foroData.cep}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={foroData.obs}
onChange={onChange}               
/>

<Checkbox label="UnicoConfirmado" name="unicoconfirmado" checked={foroData.unicoconfirmado} onChange={onChange} />
        
<Input
type="text"
id="web"
label="Web"
className="inputIncNome"
name="web"
value={foroData.web}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarecords${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?foro=${foroData.id}`)}>Agenda Records</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/divisaotribunal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?foro=${foroData.id}`)}>Divisao Tribunal</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/instancia${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?foro=${foroData.id}`)}>Instancia</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/poderjudiciarioassociado${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?foro=${foroData.id}`)}>Poder Judiciario Associado</div>

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
 