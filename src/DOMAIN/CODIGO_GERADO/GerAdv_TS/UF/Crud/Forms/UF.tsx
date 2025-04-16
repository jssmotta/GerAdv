"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IUF } from '../../Interfaces/interface.UF';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import PaisesComboBox from '@/app/GerAdv_TS/Paises/ComboBox/Paises';
import { PaisesApi } from '@/app/GerAdv_TS/Paises/Apis/ApiPaises';

interface UFFormProps {
    ufData: IUF;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const UFForm: React.FC<UFFormProps> = ({
    ufData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomePaises, setNomePaises] = useState('');
            const paisesApi = new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("paises") > 0) {
  paisesApi
    .getById(getParamFromUrl("paises"))
    .then((response) => {
      setNomePaises(response.data.inome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (ufData.id === 0) {
    ufData.pais = getParamFromUrl("paises");
  }
}
 const addValorPais = (e: any) => {
                        if (e?.id>0)
                        ufData.pais = e.id;
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
  {nomePaises && (<h2>{nomePaises}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="iduf"
            label="iduf"
            className="inputIncNome"
            name="iduf"
            value={ufData.iduf}
            onChange={onChange}
            required
          />

<Input
type="text"
id="ddd"
label="DDD"
className="inputIncNome"
name="ddd"
value={ufData.ddd}
onChange={onChange}               
/>

            <PaisesComboBox
            name={'pais'}
            value={ufData.pais}
            setValue={addValorPais}
            label={'Paises'}
            />

<Checkbox label="Top" name="top" checked={ufData.top} onChange={onChange} />
        
<Input
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={ufData.descricao}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/cidade${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?uf=${ufData.id}`)}>Cidade</div>

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
 