// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IContatoCRMView } from "../../Interfaces/interface.ContatoCRMView";
import { ContatoCRMViewService } from "../../Services/ContatoCRMView.service";
import { ContatoCRMViewApi } from "../../Apis/ApiContatoCRMView";
import ContatoCRMViewWindow from "./ContatoCRMViewWindow";

interface ContatoCRMViewWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ContatoCRMViewWindowId: React.FC<ContatoCRMViewWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const contatocrmviewService = useMemo(() => {
        return new ContatoCRMViewService(
            new ContatoCRMViewApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IContatoCRMView | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await contatocrmviewService.fetchContatoCRMViewById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ContatoCRMViewWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedContatoCRMView={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ContatoCRMViewWindowId;