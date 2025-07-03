import React from 'react';
import { render } from '@testing-library/react';
import AdvogadosIncContainer from '@/app/GerAdv_TS/Advogados/Components/AdvogadosIncContainer';
// AdvogadosIncContainer.test.tsx
// Mock do AdvogadosInc
jest.mock('@/app/GerAdv_TS/Advogados/Crud/Inc/Advogados', () => (props: any) => (
<div data-testid='advogados-inc-mock' {...props} />
));
describe('AdvogadosIncContainer', () => {
  it('deve renderizar AdvogadosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AdvogadosIncContainer id={id} navigator={mockNavigator} />
  );
  const advogadosInc = getByTestId('advogados-inc-mock');
  expect(advogadosInc).toBeInTheDocument();
  expect(advogadosInc.getAttribute('id')).toBe(id.toString());

});
});