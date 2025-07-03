import React from 'react';
import { render } from '@testing-library/react';
import NEPalavrasChavesIncContainer from '@/app/GerAdv_TS/NEPalavrasChaves/Components/NEPalavrasChavesIncContainer';
// NEPalavrasChavesIncContainer.test.tsx
// Mock do NEPalavrasChavesInc
jest.mock('@/app/GerAdv_TS/NEPalavrasChaves/Crud/Inc/NEPalavrasChaves', () => (props: any) => (
<div data-testid='nepalavraschaves-inc-mock' {...props} />
));
describe('NEPalavrasChavesIncContainer', () => {
  it('deve renderizar NEPalavrasChavesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <NEPalavrasChavesIncContainer id={id} navigator={mockNavigator} />
  );
  const nepalavraschavesInc = getByTestId('nepalavraschaves-inc-mock');
  expect(nepalavraschavesInc).toBeInTheDocument();
  expect(nepalavraschavesInc.getAttribute('id')).toBe(id.toString());

});
});