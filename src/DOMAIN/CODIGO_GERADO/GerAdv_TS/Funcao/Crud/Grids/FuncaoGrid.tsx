//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { FuncaoEmpty } from "../../../Models/Funcao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import FuncaoInc from "../Inc/Funcao";
import { IFuncao } from "../../Interfaces/interface.Funcao";
import { FuncaoService } from "../../Services/Funcao.service";
import { FuncaoApi } from "../../Apis/ApiFuncao";
import { FuncaoGridMobileComponent } from "../GridsMobile/Funcao";
import { FuncaoGridDesktopComponent } from "../GridsDesktop/Funcao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterFuncao } from "../../Filters/Funcao";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import FuncaoWindow from "./FuncaoWindow";

const FuncaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [funcao, setFuncao] = useState<IFuncao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedFuncao, setSelectedFuncao] = useState<IFuncao>(FuncaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterFuncao | undefined | null>(null);

    const funcaoService = useMemo(() => {
      return new FuncaoService(
          new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchFuncao = async (filtro?: FilterFuncao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await funcaoService.getList(filtro ?? {} as FilterFuncao);
        setFuncao(data);
      }
      else {
        const data = await funcaoService.getAll(filtro ?? {} as FilterFuncao);
        setFuncao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchFuncao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (funcao: IFuncao) => {
      if (isMobile) {
        router.push(`/pages/funcao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${funcao.id}`);
      } else {
        setSelectedFuncao(funcao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/funcao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedFuncao(FuncaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchFuncao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const funcao = e.dataItem;		
        setDeleteId(funcao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchFuncao(currFilter);
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
           <FuncaoGridMobileComponent data={funcao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <FuncaoGridDesktopComponent data={funcao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <FuncaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedFuncao={selectedFuncao}>       
        </FuncaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default FuncaoGrid;