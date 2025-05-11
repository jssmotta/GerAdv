// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAndamentosMD } from "../../Interfaces/interface.AndamentosMD";
import { AndamentosMDService } from "../../Services/AndamentosMD.service";
import { AndamentosMDApi } from "../../Apis/ApiAndamentosMD";
import AndamentosMDWindow from "./AndamentosMDWindow";

interface AndamentosMDWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AndamentosMDWindowId: React.FC<AndamentosMDWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const andamentosmdService = useMemo(() => {
        return new AndamentosMDService(
            new AndamentosMDApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAndamentosMD | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await andamentosmdService.fetchAndamentosMDById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AndamentosMDWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAndamentosMD={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AndamentosMDWindowId;