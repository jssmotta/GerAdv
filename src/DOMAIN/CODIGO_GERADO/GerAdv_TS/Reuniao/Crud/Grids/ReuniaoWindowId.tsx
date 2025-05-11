// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IReuniao } from "../../Interfaces/interface.Reuniao";
import { ReuniaoService } from "../../Services/Reuniao.service";
import { ReuniaoApi } from "../../Apis/ApiReuniao";
import ReuniaoWindow from "./ReuniaoWindow";

interface ReuniaoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ReuniaoWindowId: React.FC<ReuniaoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const reuniaoService = useMemo(() => {
        return new ReuniaoService(
            new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IReuniao | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await reuniaoService.fetchReuniaoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ReuniaoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedReuniao={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ReuniaoWindowId;