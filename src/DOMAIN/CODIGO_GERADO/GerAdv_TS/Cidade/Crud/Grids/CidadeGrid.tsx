//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { CidadeEmpty } from "../../../Models/Cidade";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ICidade } from "../../Interfaces/interface.Cidade";
import { CidadeService } from "../../Services/Cidade.service";
import { CidadeApi } from "../../Apis/ApiCidade";
import { CidadeGridMobileComponent } from "../GridsMobile/Cidade";
import { CidadeGridDesktopComponent } from "../GridsDesktop/Cidade";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterCidade } from "../../Filters/Cidade";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import CidadeWindow from "./CidadeWindow";

const CidadeGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [cidade, setCidade] = useState<ICidade[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedCidade, setSelectedCidade] = useState<ICidade>(CidadeEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterCidade | undefined | null>(null);

    const cidadeService = useMemo(() => {
      return new CidadeService(
          new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchCidade = async (filtro?: FilterCidade | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await cidadeService.getList(filtro ?? {} as FilterCidade);
        setCidade(data);
      }
      else {
        const data = await cidadeService.getAll(filtro ?? {} as FilterCidade);
        setCidade(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchCidade(currFilter);
    }, [showInc]);
  
    const handleRowClick = (cidade: ICidade) => {
      if (isMobile) {
        router.push(`/pages/cidade/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${cidade.id}`);
      } else {
        setSelectedCidade(cidade);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/cidade/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedCidade(CidadeEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchCidade(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const cidade = e.dataItem;		
        setDeleteId(cidade.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchCidade(currFilter);
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
           <CidadeGridMobileComponent data={cidade} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <CidadeGridDesktopComponent data={cidade} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <CidadeWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedCidade={selectedCidade}>       
        </CidadeWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default CidadeGrid;