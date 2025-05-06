//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { RegimeTributacaoEmpty } from "../../../Models/RegimeTributacao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IRegimeTributacao } from "../../Interfaces/interface.RegimeTributacao";
import { RegimeTributacaoService } from "../../Services/RegimeTributacao.service";
import { RegimeTributacaoApi } from "../../Apis/ApiRegimeTributacao";
import { RegimeTributacaoGridMobileComponent } from "../GridsMobile/RegimeTributacao";
import { RegimeTributacaoGridDesktopComponent } from "../GridsDesktop/RegimeTributacao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterRegimeTributacao } from "../../Filters/RegimeTributacao";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import RegimeTributacaoWindow from "./RegimeTributacaoWindow";

const RegimeTributacaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [regimetributacao, setRegimeTributacao] = useState<IRegimeTributacao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedRegimeTributacao, setSelectedRegimeTributacao] = useState<IRegimeTributacao>(RegimeTributacaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterRegimeTributacao | undefined | null>(null);

    const regimetributacaoService = useMemo(() => {
      return new RegimeTributacaoService(
          new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchRegimeTributacao = async (filtro?: FilterRegimeTributacao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await regimetributacaoService.getList(filtro ?? {} as FilterRegimeTributacao);
        setRegimeTributacao(data);
      }
      else {
        const data = await regimetributacaoService.getAll(filtro ?? {} as FilterRegimeTributacao);
        setRegimeTributacao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchRegimeTributacao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (regimetributacao: IRegimeTributacao) => {
      if (isMobile) {
        router.push(`/pages/regimetributacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${regimetributacao.id}`);
      } else {
        setSelectedRegimeTributacao(regimetributacao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/regimetributacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedRegimeTributacao(RegimeTributacaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchRegimeTributacao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const regimetributacao = e.dataItem;		
        setDeleteId(regimetributacao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchRegimeTributacao(currFilter);
            } catch {
            // falta uma mensagem de erro
            } finally {
            setDeleteId(null);
                setIsModalOpen(false);
            }
        }
    };
      
    const cancelDelete = () => {
        setDeleteId(null);
        setIsModalOpen(false);
    };

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <RegimeTributacaoGridMobileComponent data={regimetributacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <RegimeTributacaoGridDesktopComponent data={regimetributacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <RegimeTributacaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedRegimeTributacao={selectedRegimeTributacao}>       
        </RegimeTributacaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default RegimeTributacaoGrid;