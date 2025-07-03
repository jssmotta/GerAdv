import React from 'react';
import { render } from '@testing-library/react';
import AgendaRepetirDiasIncContainer from '@/app/GerAdv_TS/AgendaRepetirDias/Components/AgendaRepetirDiasIncContainer';
// AgendaRepetirDiasIncContainer.test.tsx
// Mock do AgendaRepetirDiasInc
jest.mock('@/app/GerAdv_TS/AgendaRepetirDias/Crud/Inc/AgendaRepetirDias', () => (props: any) => (
<div data-testid='agendarepetirdias-inc-mock' {...props} />
));
describe('AgendaRepetirDiasIncContainer', () => {
  it('deve renderizar AgendaRepetirDiasInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AgendaRepetirDiasIncContainer id={id} navigator={mockNavigator} />
  );
  const agendarepetirdiasInc = getByTestId('agendarepetirdias-inc-mock');
  expect(agendarepetirdiasInc).toBeInTheDocument();
  expect(agendarepetirdiasInc.getAttribute('id')).toBe(id.toString());

});
});