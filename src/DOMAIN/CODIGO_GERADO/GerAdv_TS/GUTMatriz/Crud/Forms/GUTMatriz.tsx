"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IGUTMatriz } from '../../Interfaces/interface.GUTMatriz';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import GUTTipoComboBox from '@/app/GerAdv_TS/GUTTipo/ComboBox/GUTTipo';
import { GUTTipoApi } from '@/app/GerAdv_TS/GUTTipo/Apis/ApiGUTTipo';

interface GUTMatrizFormProps {
    gutmatrizData: IGUTMatriz;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTMatrizForm: React.FC<GUTMatrizFormProps> = ({
    gutmatrizData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTTipo, setNomeGUTTipo] = useState('');
            const guttipoApi = new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("guttipo") > 0) {
  guttipoApi
    .getById(getParamFromUrl("guttipo"))
    .then((response) => {
      setNomeGUTTipo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutmatrizData.id === 0) {
    gutmatrizData.guttipo = getParamFromUrl("guttipo");
  }
}
 const addValorGUTTipo = (e: any) => {
                        if (e?.id>0)
                        gutmatrizData.guttipo = e.id;
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
  {nomeGUTTipo && (<h2>{nomeGUTTipo}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={gutmatrizData.descricao}
            onChange={onChange}
            required
          />

            <GUTTipoComboBox
            name={'guttipo'}
            value={gutmatrizData.guttipo}
            setValue={addValorGUTTipo}
            label={'G U T Tipo'}
            />

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={gutmatrizData.valor}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gutatividadesmatriz${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?gutmatriz=${gutmatrizData.id}`)}>G U T Atividades Matriz</div>

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
 